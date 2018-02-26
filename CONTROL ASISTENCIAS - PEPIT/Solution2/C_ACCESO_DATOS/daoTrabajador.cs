using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_ENTIDAD;
using System.Data;
using System.Data.SqlClient;

namespace C_ACCESO_DATOS
{
    public class daoTrabajador
    {
        #region patron singleton
        public static readonly daoTrabajador _instancia = new daoTrabajador();
        public static daoTrabajador Instancia { get { return daoTrabajador._instancia; } }
        #endregion

        #region metodos
        public List<Trabajador> ListarTrabajador()
        {
            SqlCommand cmd = null;
            List<Trabajador> lista = new List<Trabajador>();
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd=new SqlCommand("spListarTrabajador", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Trabajador t = new Trabajador();
                    t.idTrabajador = Convert.ToInt16(dr["id"]);
                    t.DNI = dr["dni"].ToString();
                    t.nombre = dr["nombre"].ToString();
                    t.apellidos = dr["apellidos"].ToString();
                    t.direccion = dr["direccion"].ToString();
                    t.correo = dr["correo"].ToString();
                    t.telefono = dr["telefono"].ToString();
                    t.documentoSisgedo = Convert.ToInt32(dr["documentoSisgedo"]);
                        TipoTrabajador ti = new TipoTrabajador();                       
                        ti.nombreTipo = dr["nombreTipo"].ToString();
                    t.tipoTrabajador = ti;
                        Facultad f = new Facultad();
                        f.nombreFacultad = dr["nombreFacultad"].ToString();
                    t.facultad = f;
                        Dependencia d = new Dependencia();
                        d.nombreDependencia = dr["nombreDepen"].ToString();
                    f.dependencia = d;
                    lista.Add(t);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public Boolean InsertarTrabajador(Trabajador t)
        {
            SqlCommand cmd = null;
            Boolean Inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spInsertarTrabajador", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prsmstrNombre", t.nombre);
                cmd.Parameters.AddWithValue("@prmstrApellido", t.apellidos);
                cmd.Parameters.AddWithValue("@prmstrDireccion", t.direccion);
                cmd.Parameters.AddWithValue("@prmstrCorreo", t.correo);
                cmd.Parameters.AddWithValue("@prmstrTelefono", t.telefono);
                cmd.Parameters.AddWithValue("@prmstrSisgedo", t.documentoSisgedo);
                cmd.Parameters.AddWithValue("@prmstrTipoTrabajador", t.tipoTrabajador.idTipoTrabajador);
                cmd.Parameters.AddWithValue("@prmstrFacultad", t.facultad.idFacultad);
                cmd.Parameters.AddWithValue("@prmstrDependencia", t.facultad.dependencia.idDependencia);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { Inserto = true; }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return Inserto;
        }
        #endregion
    }
}
