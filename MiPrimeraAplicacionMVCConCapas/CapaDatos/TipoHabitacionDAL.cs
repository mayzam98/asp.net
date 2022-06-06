using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class TipoHabitacionDAL
    {
        //public List<TipoHabitacionCLS> listarTipoHabitacion()
        //{
        //    List<TipoHabitacionCLS> lista = new List<TipoHabitacionCLS>();

        //    ////lista.Add(new TipoHabitacionCLS {
        //    ////    id = 1,
        //    ////    nombre = "simple",
        //    ////    descripcion = "Solo para uno"
        //    ////});

        //    ////lista.Add(new TipoHabitacionCLS
        //    ////{
        //    ////    id = 1,
        //    ////    nombre = "doble",
        //    ////    descripcion = "Para dos"
        //    ////});

        //    return lista;
        //}
        public List<TipoHabitacionCLS> listarTipoHabitacion() {
            List<TipoHabitacionCLS> lista = null;
            using (SqlConnection cn  = new SqlConnection("server=DESKTOP-DOBBGRU;database=BDHotel;Integrated Security=true;"))
            {//si fuera autenticacion windows Integrated Security=true
                try
                {
                    //Abro la conneccion
                    cn.Open();
                    //Llama al procedure
                    using (SqlCommand cmd = new SqlCommand("uspListarTipoHabitacion", cn))
                    {
                        //Buena practica indicamos  que es un procedure haciendo using system.data
                        cmd.CommandType = CommandType.StoredProcedure;
                        //ejecutar
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<TipoHabitacionCLS>();
                            while (drd.Read())
                            {
                            }
                        }
                        //Cierro una vez de traer la data
                        cn.Close();
                    }
                }

                catch (Exception ex)
                {
                    cn.Close();
                    throw;
                }
            }
                return lista;
        }
    }
}
