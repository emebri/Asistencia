using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_ENTIDAD
{
    public class Trabajador
    {
        public int idTrabajador { get; set; }
        public String nombre { get; set; }
        public String apellidos { get; set; }
        public String DNI { get; set; }
        public String direccion { get; set; }
        public String correo { get; set; }
        public String telefono { get; set; }
        public int documentoSisgedo { get; set; } 
        public Facultad facultad { get; set; }
        public TipoTrabajador tipoTrabajador { get; set; }

    }
}
