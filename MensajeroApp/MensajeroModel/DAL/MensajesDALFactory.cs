using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeroModel.DAL
{
    /*patron de diseño singleton*/
    public class MensajesDALFactory
    {
        public static IMensajesDAL CreateDal()
        {
            return MensajesDALArchivos.GetInstancia();
        }
    }
}
