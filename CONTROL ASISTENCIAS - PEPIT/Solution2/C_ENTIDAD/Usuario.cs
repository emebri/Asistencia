using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_ENTIDAD
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        
        public String nombreUsuario { get; set; }
        public String password { get; set; }
        public Boolean estadoActivo { get; set; }
        public DateTime fechaCreacion { get; set; }
        public Trabajador trabajador { get; set; }


    }
}
