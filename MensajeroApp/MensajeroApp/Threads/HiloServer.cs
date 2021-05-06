using SocketUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MensajeroApp.Threads
{
    public class HiloServer
    {
        /*puerto donde iniciara el server*/
        private int puerto;
        /*atributo instancia serverSocket
         que tiene los metodos para iniciar el server*/
        private ServerSocket server;

        public HiloServer(int puerto)
        {
            this.puerto = puerto;
        }

        public void Ejecutar()
        {
            /*inicio nueva instancia*/
            server = new ServerSocket(puerto);
            Console.WriteLine("Iniciando server en puerto{0}", puerto);
            /*soy capaz de iniciar el server?*/
            if (server.Iniciar())
            {
                Console.WriteLine("Servidor Iniciado");
                while (true)
                {
                    /*pido clientes*/
                    Console.WriteLine("Esperando Clientes...");
                    /*metodo que devuelven cliente socket*/
                    ClienteSocket clienteSocket = server.ObtenerCliente();
                    /*creo instancia del HiloCliente*/
                    HiloCliente hiloCliente = new HiloCliente(clienteSocket);
                    /*se llama al metodo ejecutar, dentro de un hilo
                      se queda el hilo en estado unstarted*/
                    Thread t = new Thread(new ThreadStart(hiloCliente.Ejecutar));
                    /*para que se cierre el hilo cuando se cierre la aplicacion*/
                    t.IsBackground = true;
                    /*se levanta el hilo*/
                    t.Start();
                }

            }
        }
    }
}
