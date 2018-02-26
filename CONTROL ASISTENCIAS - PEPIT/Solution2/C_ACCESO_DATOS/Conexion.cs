using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace C_ACCESO_DATOS
{
    public class Conexion
    {
        #region patron singleton
        public static readonly Conexion _instancia = new Conexion();
        public static Conexion Instancia { get { return Conexion._instancia; } }
        #endregion

        #region metodos
        public SqlConnection conectar()
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = "Data Source=.; Initial Catalog=BDASISTENCIA; Integrated Security=true";
                return cn;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
