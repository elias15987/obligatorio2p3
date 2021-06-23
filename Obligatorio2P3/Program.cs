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
                dbContext.Database.Delete();
                dbContext.Database.CreateIfNotExists();

                Console.WriteLine("Iniciando Importacion");
                Console.WriteLine("");
                var res = new ImportarArchivos().ImportarUsuarios();
                Console.WriteLine("");
                Console.WriteLine("Finalizado");
            }
        }
    }
}
