using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    [Table("VACUNAS")]
    public class Vacunas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        //public List<Laboratorios> Laboratorios { get; set; }
        public string Tipo { get; set; }
        public int CantDosis { get; set; }
        public int LapsoEntreDosisDias { get; set; }
        public int EdadMin { get; set; }
        public int EdadMax { get; set; }
        public double EficaciaCovid { get; set; }
        public double PrevenirHospitalizacion { get; set; }
        public double PrevenirCTI { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int FaseClinica { get; set; }
        //public List<Paises> Estatus { get; set; }
        public int Emergencia { get; set; }
        public string Efectos { get; set; }
        public double Precio { get; set; }
        public int CantDosisProd { get; set; }
        public int Covax { get; set; }
        public string UsuarioRegistro { get; set; }
        public string UsuarioEdit { get; set; }
        public DateTime FechaEdit { get; set; }

        public ICollection<vacunaLab> vacunaLabs { get; set; }
        public ICollection<vacunaPais> vacunaPais { get; set; }

        //public Vacunas()
        //{
        //    Estatus = new List<Paises>();
        //    Laboratorios = new List<Laboratorios>();
        //}
    }
}
