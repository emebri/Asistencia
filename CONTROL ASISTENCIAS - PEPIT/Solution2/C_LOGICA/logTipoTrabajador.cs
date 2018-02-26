using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_ENTIDAD;
using C_ACCESO_DATOS;

namespace C_LOGICA
{
    public class logTipoTrabajador
    {
        #region patron singleton
        public static readonly logTipoTrabajador _instancia = new logTipoTrabajador();
        public static logTipoTrabajador Instancia { get { return logTipoTrabajador._instancia; } }
        #endregion

        #region metodos
        public List<TipoTrabajador> ListarTipoTrabajador(Boolean soloActivos)
        {
            try
            {
                List<TipoTrabajador> lista = daoTipoTrabajador.Instancia.ListarTipoTrabajador();
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

        #endregion

    }
}
