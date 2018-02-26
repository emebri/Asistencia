using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_ENTIDAD;
using C_ACCESO_DATOS;

namespace C_LOGICA
{
    public class logTrabajador
    {
        #region patron singleton
        public static readonly logTrabajador _instancia = new logTrabajador();
        public static logTrabajador Instancia { get { return logTrabajador._instancia; } }
        #endregion

        #region metodos
        public List<Trabajador> ListarTrabajador()
        {
            try
            {
                return daoTrabajador.Instancia.ListarTrabajador();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean InsertarTrabajador(Trabajador t)
        {
            try
            {
                if (t.documentoSisgedo == 0)
                {
                    throw new ApplicationException("Debe ingresar documento sisgedo");
                }
                return daoTrabajador.Instancia.InsertarTrabajador(t);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        #endregion
    }
}
