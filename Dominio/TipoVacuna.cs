using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    [Table("TIPOVACUNA")]
    public class TipoVacuna
    {
        [Key]   
        public string Cod { get; set; }
        public string Descripcion { get; set; }
    }
}
