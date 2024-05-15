using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ExamenC.Entidades
{
    public class Conferencia
    {
        public int Id { get; set; } // Clave Primaria
        public string Nombre { get; set; }
        public string Lugar { get; set; }
        public DateTime? FechaInicio { get; set; }

        // Relación uno a muchos con Ponente
        public List<Ponente>? Ponentes { get; set; }
    }
}
