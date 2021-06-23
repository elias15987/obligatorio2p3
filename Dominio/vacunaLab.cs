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
        [ForeignKey("Vacuna")]
        public int VacunaId { get; set; }
        public virtual Vacunas Vacuna { get; set; }
        [ForeignKey("Laboratorio")]
        public int LaboratorioId { get; set; }
        public virtual Laboratorios Laboratorio { get; set; }
    }
}
