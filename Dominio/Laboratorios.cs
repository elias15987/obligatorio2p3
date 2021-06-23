using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    [Table("LABORATORIOS")]
    public class Laboratorios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string PaisOrigen { get; set; }
        public bool Exp { get; set; }

        public ICollection<vacunaLab> vacunaLab { get; set; }

    }
}
