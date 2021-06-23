using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    [Table("USUARIOS")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Required,MaxLength(8), Index(IsUnique = true)]
        public string Ci { get; set; }
        [Required]
        public string Pass { get; set; }
        public bool Autorizado { get; set; }
        public bool CambioPrimeraPass { get; set; }
    }
}
