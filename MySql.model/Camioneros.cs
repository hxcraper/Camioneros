using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySql.model
{
    public class Camioneros
    {
        public string? id { get; set; }
        public string? nombre { get; set; }

        public string? apellidos { get; set; }

        public string? edad { get; set; }
        public string? tipoLicencia { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string? direccion { get; set; }

        public int telefono { get; set; }

    }
}