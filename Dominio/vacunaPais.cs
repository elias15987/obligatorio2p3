using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    [Table("VACUNAPAIS")]
    public class vacunaPais
    {
        public int Id { get; set; }
        public Vacunas vacuna { get; set; }
        public Paises pais { get; set; }
    }
}
