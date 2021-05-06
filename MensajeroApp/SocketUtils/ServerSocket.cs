using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketUtils
{
    public class ServerSocket
    {
        /*Atributo del puerto*/
        private int puerto;

        /*Se define como atributo variable de tipo Socket que sera el servidor*/
        private Socket servidor;



        /*Constructor que recibe el puerto*/
        public ServerSocket(int puerto)
        {
            this.puerto = puerto;
        }

        /*Levanta la conexion*/
        public Boolean Iniciar()
        {
            /*se hace boolean porque pude explotar*/
            try
            {
                //1. Crear Socket
                /*se crea instancia
                 Que tipo de conexion de red soporta, de que tipo es el socket, protocolo*/
                this.servidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //2 Tomar control del puerto
                /*recibe un EndPoint
                 recibe IPAddress que reprecenta las direcciones desde las cual se podran conectar a este socket
                 y recibe el puerto*/
                /*si esta linea no pasa
                 cae en excepsion como false y el inicio va a dar error*/
                this.servidor.Bind(new IPEndPoint(IPAddress.Any, this.puerto));

                //3. Definir cuantos clientes atenderé
                /*cuando la aplicacion es concurrente tiene sentido poner 10*/
                this.servidor.Listen(10);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /*Obtiene el cliente*/
        public ClienteSocket ObtenerCliente()
        {
            try
            {
                /*recibo la comunicacion con cliente y lo guardo aca
                 se queda esperando hasta que llegue un cliente*/
                return new ClienteSocket(this.servidor.Accept());
            }
            catch (Exception ex)
            {
                return null;
            }

        }
 
    }
}
