using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    [Table ("PAISES")]
    public class Paises
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<vacunaPais> vacunaPais { get; set; }
    }
}
