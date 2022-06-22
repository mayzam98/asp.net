using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;


namespace CapaNegocio
{
    public class CamaBLL
    {
        public List<CamaCLS> listarCama()
        {
            CamaDAL oCamaDAL = new CamaDAL();
            return oCamaDAL.listarCama();

        }
    }
}
