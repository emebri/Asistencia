using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_ENTIDAD
{
    public class Facultad
    {
        public int idFacultad { get; set; }
        public String nombreFacultad { get; set; }
        public Boolean activo { get; set; }
        public Dependencia dependencia { get; set; }

    }
}
