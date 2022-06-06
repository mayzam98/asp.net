using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class TipoHabitacionBLL
    {
        public List<TipoHabitacionCLS> listarTipoHabitacion()
        {
            TipoHabitacionDAL otipoHabitacionDAL = new TipoHabitacionDAL();
            return otipoHabitacionDAL.listarTipoHabitacion();
        }

    }
}
