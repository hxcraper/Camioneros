using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySql.model
{
   public class Camiones

    {
        public string? camion_id { get; set; }
        public string? marca { get; set; }
        public string? modelo { get; set; }
        public string? patente { get; set; }
        public string? dueño { get; set; }
        public DateTime año { get; set; }

        public decimal pesoneto { get; set; }

        public double capacidad { get; set; }

    }
}
