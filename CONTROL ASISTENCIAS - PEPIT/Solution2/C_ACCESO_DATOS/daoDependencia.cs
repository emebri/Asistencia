using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using C_ENTIDAD;

namespace C_ACCESO_DATOS
{
    public class daoDependencia
    {
        #region patron singleton
        public static readonly daoDependencia _instancia = new daoDependencia();
        public static daoDependencia Instancia { get { return daoDependencia._instancia; } }
        #endregion


        public List<Dependencia> ListarDependencia()
        {
            SqlCommand cmd = null;
            List<Dependencia> lista = new List<Dependencia>();
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spListarDependencia", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Dependencia d = new Dependencia();
                    d.idDependencia = Convert.ToInt16(dr["id"]);
                    d.nombreDependencia = dr["nombreDepen"].ToString();
                    d.activo = Convert.ToBoolean(dr["activo"]);
                    lista.Add(d);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }
    }
}