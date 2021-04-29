using MensajeroModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeroModel.DAL
{
    public interface IMensajesDAL
    {
        /*Dos operaciones que tiene esta clase,
         si hubieran mas, se agregan mas*/
        void Save(Mensaje m);
        List<Mensaje> GetAll();
    }
}
