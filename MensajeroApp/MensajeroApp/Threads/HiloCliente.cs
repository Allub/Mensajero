using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MensajeroModel.DAL;
using MensajeroModel.DTO;
using SocketUtils;

namespace MensajeroApp.Threads
{
    class HiloCliente
    {
        private ClienteSocket clienteSocket;
        private IMensajesDAL dal = MensajesDALFactory.CreateDal();
        public HiloCliente(ClienteSocket clienteSocket)
        {
            this.clienteSocket = clienteSocket;
        }

        /*cuando se recibe el cliente*/
        public void Ejecutar()
        {
            String nombre, detalle;
            do
            {
                clienteSocket.Escribir("Ingresar nombre:");
                nombre = clienteSocket.Leer().Trim();

            } while (nombre == String.Empty);

            do
            {
                clienteSocket.Escribir("Ingrese mensaje:");
                detalle = clienteSocket.Leer().Trim();

            } while (detalle == String.Empty || detalle.Length > 20);

            Mensaje m = new Mensaje()
            {
                Nombre = nombre,
                Detalle = detalle,
                Tipo = "TCP"
            };
            /*me aseguro que hago un bloqueo del objeto
             nadie mas puede acceder al objeto hasta que no lo haya liberado*/
            lock (dal)
            {
                dal.Save(m);
            }
            clienteSocket.CerrarConexion();
        }
    }
}
