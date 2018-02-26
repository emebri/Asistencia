using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_ENTIDAD
{
    public class Asistencia
    {
        public int idAsistencia { get; set; }
        public DateTime fecha { get; set; }
        public DateTime horaEntrada { get; set; }
        public Decimal minutosTrabajados { get; set; }
        public DateTime horaSalida { get; set; }
        public Usuario usuario { get; set; }

    }
}
