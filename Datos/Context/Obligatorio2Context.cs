using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Dominio;

namespace Datos.Context
{
    public class Obligatorio2Context : DbContext
    {
        public DbSet<Laboratorios> Laboratorios { get; set; }
        public DbSet<Paises> Paises { get; set; }
        public DbSet<TipoVacuna> TipoVacunas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<vacunaLab> VacunaLabs { get; set; }
        public DbSet<vacunaPais> VacunaPais { get; set; }
        public DbSet<Vacunas> Vacunas { get; set; }

        public Obligatorio2Context() : base("MiConexion")
        {
        }
    }
}
