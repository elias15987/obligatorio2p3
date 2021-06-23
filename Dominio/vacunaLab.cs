using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    [Table("VACUNALAB")]
    public class vacunaLab
    {
        public int Id { get; set; }
        public Vacunas vacuna { get; set; }
        public Laboratorios laboratorio { get; set; }
    }
}
