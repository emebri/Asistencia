using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_ENTIDAD;
using C_ACCESO_DATOS;

namespace C_LOGICA
{
    public class logFacultad
    {
        #region patron singleton
        public static readonly logFacultad _instancia = new logFacultad();
        public static logFacultad Instancia { get { return logFacultad._instancia; } }
        #endregion

        #region metodos
        public List<Facultad> ListarFacultad(Boolean soloActivos)
        {
            try
            {
                List<Facultad> lista = daoFacultad.Instancia.ListarFacultad();
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
