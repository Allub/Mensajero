using MensajeroApp.Threads;
using MensajeroModel.DAL;
using MensajeroModel.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MensajeroApp
{
    public partial class Program
    {
       


        static void Main(string[] args)
        {
            /*convertir el puerto*/
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            Console.WriteLine("Iniciando Hilo del server Socket");
            /*creo instancia del hiloServer, se le pasa el puerto*/
            HiloServer hiloServer = new HiloServer(puerto);
            /*se llama al metodo ejecutar, dentro de un hilo
             se queda el hilo en estado unstarted*/
            Thread t = new Thread(new ThreadStart(hiloServer.Ejecutar));
            /*para que se cierre el hilo cuando se cierre la aplicacion*/
            t.IsBackground = true;
            /*se levanta el hilo*/
            t.Start();
            
            while (Menu());
        }
    }
}
