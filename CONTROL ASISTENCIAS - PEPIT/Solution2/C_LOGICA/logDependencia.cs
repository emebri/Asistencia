using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_ENTIDAD;
using C_ACCESO_DATOS;

namespace C_LOGICA
{
    public class logDependencia
    {
        #region patron singleton
        public static readonly logDependencia _instancia = new logDependencia();
        public static logDependencia Instancia { get { return logDependencia._instancia; } }
        #endregion

        public List<Dependencia> ListarDependencia(Boolean soloActivos)
        {
            try
            {
                List<Dependencia> lista = daoDependencia.Instancia.ListarDependencia();
                if (soloActivos)
                {
                    foreach (var item in lista)
                    {
                        if (!item.activo)
                        {
                            lista.Remove(item);
                        }
                    }
                }
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
