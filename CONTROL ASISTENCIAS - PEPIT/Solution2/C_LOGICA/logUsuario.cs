using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_ACCESO_DATOS;
using C_ENTIDAD;

namespace C_LOGICA
{
    public class logUsuario
    {
        #region patron singleton
        public static readonly logUsuario _instancia = new logUsuario();
        public static logUsuario Instancia { get { return logUsuario._instancia; } }
        #endregion

        #region metodos
        public Usuario VerificarAcceso(String Usuario, String Password)
        {
            try
            {
                if (DateTime.Now.Hour <8)
                {
                    throw new ApplicationException("No hora permitida");
                }
                
                Usuario u = daoUsuario.Instancia.VerificarAcceso(Usuario, Password);
                if (u != null)
                {
                    if (!u.estadoActivo)
                    {
                        throw new ApplicationException("Usuario bajo");
                    }
                }
                else
                {
                    throw new ApplicationException("Datos incorrectos");
                }
                return u;
            }
            catch (Exception e)
            {
                throw e;
            }
            #endregion

        }

    }
}
