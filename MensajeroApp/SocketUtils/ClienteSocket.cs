using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketUtils
{
    public class ClienteSocket
    {
        /*Se define como atributo un socket que represente la comunicacion activa con el cliente*/
        private Socket comCliente;

        /*instancias que necesito para cuando se reciba el cliente
         leer desde el cliente
         y escribir al cliente*/
        private StreamReader reader;
        private StreamWriter writer;

        /*Constructor que recibe un socket tipo comCliente
         * para comunicacion con el cliente*/
        public ClienteSocket(Socket comCliente)
        {
            this.comCliente = comCliente;
            /*stream se crea a partir del socket
            La conexion entre cliente y servidor se llama comCliente de tipo socket
            la carretera para enviar los datos de un extremo a otro es el Stream
            en esa carretera necesito lo que manda la info de un extremo a otro
            estos se llaman StreamReader y StreamWriter*/
            /*Stream(Socket)
             SW(Stream)
             SR(Stream)*/
            Stream stream = new NetworkStream(this.comCliente);
            /*stream se le pasa al Writer y Reader*/
            this.writer = new StreamWriter(stream);
            this.reader = new StreamReader(stream);
        }

        /*Permite mandar el mensaje al cliente*/
        public bool Escribir(String mensaje)
        {

            try
            {
                /*Metodos para escribir mensajes al cliente*/
                this.writer.WriteLine(mensaje);
                this.writer.Flush();
                return true;
            }
            catch (IOException ex)
            {

                return false;
            }

        }
        /*Permite recibir valor del cliente*/
        public String Leer()
        {
            try
            {
                /*metodo para leer mensajes del cliente*/
                return this.reader.ReadLine().Trim();
            }
            catch (IOException ex)
            {
                //return null porque es string
                return null;
            }

        }
        /*Permite cerrar conexion del cliente*/
        public void CerrarConexion()
        {
            this.comCliente.Close();

        }

    }
}
