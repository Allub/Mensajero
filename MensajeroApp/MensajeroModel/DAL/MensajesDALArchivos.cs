using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MensajeroModel.DTO;

namespace MensajeroModel.DAL
{
    /*hereda de IMensajesDAL*/
    public class MensajesDALArchivos : IMensajesDAL
    {
        //Singleton:Una instancia de esta clase por programa
        //1. Un constructor privado
        private MensajesDALArchivos()
        {

        }
        //2. una referencia estatica a si mismo
        /*parte en null*/
        private static IMensajesDAL instancia;
        //3. un metodo estatico que sea el unico que permite acceder a la instancia
        public static IMensajesDAL GetInstancia()
        {
            /*si intancia es null
             no hay ninguna instancia, entonces se crea nuevo objeto 
             y retorna la instancia*/
            if (instancia == null)
                instancia = new MensajesDALArchivos();
            return instancia;
            
        }

        /*ruta donde se guarda el archivo
         Directory.GetCurrentDirectory = devuelve una url(string) en donde esta el projecto
         en la carpeta debug
         Path.DirectorySeparatorChar = representa "/"
         se pone nombre del archivo*/
        private String archivo = Directory.GetCurrentDirectory()
            + Path.DirectorySeparatorChar + "mensajes.csv";



        /*retorna lista de mensajes*/
        public List<Mensaje> GetAll()
        {
            /*se genera lista vacia*/
            List<Mensaje> mensajes = new List<Mensaje>();
            try
            {
                /*cuando se le pasa el archivo, automaticamente hace string del archivo*/
                using (StreamReader reader = new StreamReader(archivo))
                {
                    /*variable que parte en null*/
                    String texto = null;
                    /*se repite mientras el texto sea distinto de null
                     cuando sea null, es porque se llegó al final del archivo*/
                    do
                    {
                        texto = reader.ReadLine();
                        /*si el texto es distinto a null*/
                        if (texto != null)
                        {
                            //Parsear el mensaje
                            /*0 nombre mensaje
                             1 detalle mensaje 
                             2 tipo mensaje*/
                            String[] textoArray = texto.Split(';');
                            /*objeto tipo mensaje*/
                            Mensaje m = new Mensaje()
                            {
                                /*constructor*/
                                Nombre = textoArray[0],
                                Detalle = textoArray[1],
                                Tipo = textoArray[2]
                            };
                            /*se agrega a la lista*/
                            mensajes.Add(m);
                        }

                    } while (texto != null);
                }
            }
            catch (IOException ex)
            {
                mensajes = null;               
            }
            return mensajes;
        }

        /*guarda el archivo*/
        public void Save(Mensaje m)
        {
            try
            {
                /*StreamWriter permite escribir en el archivo
                 se le pasa la url del archivo y boolean en true, si el archivo no existe, lo crea
                 using es para cuando levante el writer, se levanta el recurso y se cierra en el ultimo bloque*/
                using (StreamWriter writer = new StreamWriter(archivo, true))
                {
                    writer.WriteLine(m);
                    writer.Flush();
                }
               
            }
            catch (IOException ex)
            {

               
            }
        }
    }
}
