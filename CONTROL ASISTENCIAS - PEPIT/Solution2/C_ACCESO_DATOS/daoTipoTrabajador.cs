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
   public class daoTipoTrabajador
    {
        #region patron singleton
        public static readonly daoTipoTrabajador _instancia = new daoTipoTrabajador();
        public static daoTipoTrabajador Instancia { get { return daoTipoTrabajador._instancia; } }
        #endregion

        public List<TipoTrabajador> ListarTipoTrabajador()
        {
            SqlCommand cmd = null;
            List<TipoTrabajador> lista = new List<TipoTrabajador>();
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spListarTipoTrabajador", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TipoTrabajador tt = new TipoTrabajador();
                    tt.idTipoTrabajador = Convert.ToInt16(dr["id"]);
                    tt.nombreTipo = dr["nombreTipo"].ToString();
                    tt.activo = Convert.ToBoolean(dr["activo"]);
                    lista.Add(tt);
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
