using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class CamaDAL : CadenaDAL
    {

        public List<CamaCLS> listarCama()
        {
            List<CamaCLS> lista = null;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena))//importante para usar autenticacion de sql server Trusted_Connection=true
            {//si fuera autenticacion windows Integrated Security=true
                try
                {
                    //Abro la conneccion
                    cn.Open();
                    //Llama al procedure
                    using (SqlCommand cmd = new SqlCommand("uspListarCama", cn))
                    {
                        //Buena practica indicamos  que es un procedure haciendo using system.data
                        cmd.CommandType = CommandType.StoredProcedure;
                        //ejecutar
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<CamaCLS>();
                            CamaCLS oCamaCLS;
                            var posicionID = drd.GetOrdinal("IIDCAMa");
                            var posicionNombre = drd.GetOrdinal("NOMBRE");
                            var posicionDescripcion = drd.GetOrdinal("DESCRIPCION");
                            while (drd.Read())
                            {
                                //en el datareader la enumeracion inicia en cero
                                //Para evitar lo anterior se usa el GetOrdinal()
                                oCamaCLS = new CamaCLS();
                                oCamaCLS.idcama = drd.GetInt32(posicionID);
                                oCamaCLS.nombre = drd.GetString(posicionNombre);
                                oCamaCLS.descripcion = drd.GetString(posicionDescripcion);
                                lista.Add(oCamaCLS);

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
