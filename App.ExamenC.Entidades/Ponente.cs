using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ExamenC.Entidades
{
    public class Ponente
    {
        public int Id { get; set; } // Clave Primaria
        public string Nombre { get; set; }
        
        public string? Tema { get; set; }

        // Relación con la conferencia
        public int ConferenciaId { get; set; } // Clave Foránea
        public Conferencia? Conferencia { get; set; }
    }
}
