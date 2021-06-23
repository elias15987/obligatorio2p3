using System;
using Datos.Context;
using Datos.Repositorios;

namespace Obligatorio2P3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            using (Obligatorio2Context dbContext = new Obligatorio2Context())
            {
                //dbContext.Database.Delete();
                dbContext.Database.CreateIfNotExists();

                Console.WriteLine("Iniciando Importacion");
                Console.WriteLine("");
                var res = new ImportarArchivos().ImportarUsuarios();
                var res2 = new ImportarArchivos().ImportarTipoVacunas();
                var res3 = new ImportarArchivos().ImportarLaboratorios();
                var res4 = new ImportarArchivos().ImportarVacunas();
                var res5 = new ImportarArchivos().ImportarLabVac();

                Console.WriteLine("");
                Console.WriteLine("Finalizado");
            }
        }
    }
}
