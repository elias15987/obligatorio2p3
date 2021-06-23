using System;
using Dominio;
using System.Collections.Generic;
using System.IO;
using Datos.Context;
using System.Linq;


namespace Datos.Repositorios
{
    public class ImportarArchivos
    {


        private readonly Obligatorio2Context dbContext = new Obligatorio2Context();



        public bool ImportarUsuarios()
        {
            string rutaAplicacion = AppDomain.CurrentDomain.BaseDirectory;

            string rutaArchivoUsuarios = Path.Combine(rutaAplicacion, "Archivos", "tablaUsuarios.txt");

            try
            {

                using (StreamReader sr = File.OpenText(rutaArchivoUsuarios))
                {
                    List<string> usuarios = new List<string>();

                    bool paseHeader = false;
                    string linea = sr.ReadLine();
                    while (!string.IsNullOrEmpty(linea))
                    {
                        if (paseHeader)
                        {
                            usuarios.Add(linea);

                        }
                        Console.WriteLine(linea);
                        linea = sr.ReadLine();
                        paseHeader = true;
                    }
                    sr.Close();

                    foreach (string u in usuarios)
                    {  
                        string[] stringSplit = u.Split(new string[] { "|" }, StringSplitOptions.None);
                        string sub = stringSplit[3].Substring(0, 4);
                        string dia = DateTime.Now.ToString("dddd").SinTildes();

                        Usuario usuario = new Usuario()
                        {
                            Ci = stringSplit[3],
                            Pass = (sub + "-" + dia.Substring(0, 1).ToUpper() + dia.Substring(1, 2)).CifrarCadena(),
                            Autorizado = true,
                            CambioPrimeraPass = false
                        };


                        Usuario existeU = dbContext.Usuarios.FirstOrDefault(x => x.Ci == usuario.Ci);

                        if(existeU == null)
                        {
                            dbContext.Usuarios.Add(usuario);
                            dbContext.SaveChanges();
                        }
                    }

                    Console.WriteLine("Usuarios Importados.");

                    return true;
                }
            }
            catch
            {
                return false;
            }

        }







        public bool ImportarTipoVacunas()
        {
            string rutaAplicacion = AppDomain.CurrentDomain.BaseDirectory;

            string rutaArchivoUsuarios = Path.Combine(rutaAplicacion, "Archivos", "tipoVacunas.txt");

            try
            {

                using (StreamReader sr = File.OpenText(rutaArchivoUsuarios))
                {
                    List<string> tiposVacunas = new List<string>();

                    bool paseHeader = false;
                    string linea = sr.ReadLine();
                    while (!string.IsNullOrEmpty(linea))
                    {
                        if (paseHeader)
                        {
                            tiposVacunas.Add(linea);

                        }
                        Console.WriteLine(linea);
                        linea = sr.ReadLine();
                        paseHeader = true;
                    }
                    sr.Close();

                    foreach (string tv in tiposVacunas)
                    {
                        string[] stringSplit = tv.Split(new string[] { "|" }, StringSplitOptions.None);
                        
                        TipoVacuna tipo = new TipoVacuna()
                        {
                           Cod = stringSplit[0].ToUpper(),
                           Descripcion = stringSplit[1]
                        };


                        TipoVacuna existeTipo = dbContext.TipoVacunas.FirstOrDefault(x => x.Cod.ToUpper() == tipo.Cod.ToUpper());

                        if (existeTipo == null)
                        {
                            dbContext.TipoVacunas.Add(tipo);
                            dbContext.SaveChanges();
                        }
                    }

                    Console.WriteLine("Tipo de vacunas Importadas.");

                    return true;
                }
            }
            catch
            {
                return false;
            }

        }





        public bool ImportarLaboratorios()
        {
            string rutaAplicacion = AppDomain.CurrentDomain.BaseDirectory;

            string rutaArchivoUsuarios = Path.Combine(rutaAplicacion, "Archivos", "laboratorios.txt");

            try
            {

                using (StreamReader sr = File.OpenText(rutaArchivoUsuarios))
                {
                    List<string> labs = new List<string>();

                    bool paseHeader = false;
                    string linea = sr.ReadLine();
                    while (!string.IsNullOrEmpty(linea))
                    {
                        if (paseHeader)
                        {
                            labs.Add(linea);

                        }
                        Console.WriteLine(linea);
                        linea = sr.ReadLine();
                        paseHeader = true;
                    }
                    sr.Close();

                    foreach (string l in labs)
                    {
                        string[] stringSplit = l.Split(new string[] { "|" }, StringSplitOptions.None);

                        Laboratorios lab = new Laboratorios()
                        {
                            Id = Int32.Parse(stringSplit[0]),
                            Nombre = stringSplit[1],
                            PaisOrigen = stringSplit[2],
                            Exp = (Int32.Parse(stringSplit[3]) == 1 ) ? true : false
                        };


                        Laboratorios existeLab = dbContext.Laboratorios.FirstOrDefault(x => x.Id == lab.Id || x.Nombre == lab.Nombre);

                        if (existeLab == null)
                        {
                            dbContext.Laboratorios.Add(lab);
                            dbContext.SaveChanges();
                        }
                    }

                    Console.WriteLine("Laboratorios Importados.");

                    return true;
                }
            }
            catch
            {
                return false;
            }

        }



    }
}
