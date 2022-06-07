using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

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
            string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena))//importante para usar autenticacion de sql server Trusted_Connection=true
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
                            TipoHabitacionCLS oTipoHabitacionCLS;
                            while (drd.Read())
                            {
                                //en el datareader la enumeracion inicia en cero
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                oTipoHabitacionCLS.id = drd.GetInt32(0);  
                                oTipoHabitacionCLS.nombre = drd.GetString(1);
                                oTipoHabitacionCLS.descripcion = drd.GetString(2);
                                lista.Add(oTipoHabitacionCLS);

                            }
                        }
                    }
                    //Cierro una vez de traer la data
                    cn.Close();
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
