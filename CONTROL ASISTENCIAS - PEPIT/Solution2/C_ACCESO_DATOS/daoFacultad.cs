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
   public class daoFacultad
    {
        #region patron singleton
        public static readonly daoFacultad _instancia = new daoFacultad();
        public static daoFacultad Instancia { get { return daoFacultad._instancia; } }
        #endregion


        public List<Facultad> ListarFacultad()
        {
            SqlCommand cmd = null;
            List<Facultad> lista = new List<Facultad>();
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spListarFacultad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Facultad f = new Facultad();
                    f.idFacultad = Convert.ToInt16(dr["id"]);
                    f.nombreFacultad = dr["nombreFacultad"].ToString();
                    f.activo = Convert.ToBoolean(dr["activo"]);
                    lista.Add(f);
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
