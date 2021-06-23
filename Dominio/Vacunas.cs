using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Dominio
{
    [Table("VACUNAS")]
    public class Vacunas
    {

        [Key]
        public int Id { get; set; }
        [Required,MaxLength(50), Index(IsUnique = true)]
        public string Nombre { get; set; }
        public List<Laboratorios> Laboratorios { get; set; }
        public virtual TipoVacuna Tipo { get; set; }
        [Required]
        public int CantDosis { get; set; }
        [Required]
        public int LapsoEntreDosisDias { get; set; }
        [Required]
        public int EdadMin { get; set; }
        [Required]
        public int EdadMax { get; set; }
        [Required, Range(0.0, 100, ErrorMessage = "Debe estar entre 0 y 100")]
        public double EficaciaCovid { get; set; }
        [Required, Range(0.0, 100, ErrorMessage = "Debe estar entre 0 y 100")]
        public double PrevenirHospitalizacion { get; set; }
        [Required, Range(0.0, 100, ErrorMessage = "Debe estar entre 0 y 100")]
        public double PrevenirCTI { get; set; }
        [Required, Range(-100, 50, ErrorMessage = "Debe estar entre -100 y 50")]
        public double TempMin { get; set; }
        [Required, Range(-100, 50, ErrorMessage = "Debe estar entre -100 y 50")]
        public double TempMax { get; set; }
        [Required, Range(1, 4, ErrorMessage = "Debe estar entre 1 y 4")]
        public int FaseClinica { get; set; }
        public string Estatus { get; set; }
        public bool Emergencia { get; set; }
        public string Efectos { get; set; }
        [DefaultValue(-1)]
        public double Precio { get; set; }
        [Required]
        public int CantDosisProd { get; set; }
        public bool Covax { get; set; }
        public string UsuarioRegistro { get; set; }
        public string UsuarioEdit { get; set; }
        public DateTime FechaEdit { get; set; }

        public ICollection<vacunaLab> vacunaLabs { get; set; }


        public Vacunas()
        {
            Laboratorios = new List<Laboratorios>();
            vacunaLabs = new HashSet<vacunaLab>();

        }
    }

    public class ValidarMenorQue : ValidationAttribute
    {
        public double Min { get; set; }
        public double Max { get; set; }

        public ValidarMenorQue()
        {
            this.Min = 0;
            this.Max = double.MaxValue;
        }

        public ValidarMenorQue(double min, double max)
        {
            this.Min = min;
            this.Max = max;
        }

        public override bool IsValid(object value)
        {
            string strValue = value as string;
            if (!string.IsNullOrEmpty(strValue))
            {
                return this.Min < this.Max;
            }
            return true;
        }
    }


}
