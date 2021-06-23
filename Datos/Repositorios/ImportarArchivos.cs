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

            string rutaArchivoTipoVacunas = Path.Combine(rutaAplicacion, "Archivos", "tipoVacunas.txt");

            try
            {

                using (StreamReader sr = File.OpenText(rutaArchivoTipoVacunas))
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

            string rutaArchivoLaboratorio = Path.Combine(rutaAplicacion, "Archivos", "laboratorios.txt");

            try
            {

                using (StreamReader sr = File.OpenText(rutaArchivoLaboratorio))
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
                            Nombre = stringSplit[1].ToUpper(),
                            PaisOrigen = stringSplit[2].ToUpper(),
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




        public bool ImportarVacunas()
        {
            string rutaAplicacion = AppDomain.CurrentDomain.BaseDirectory;

            string rutaArchivoVacunas = Path.Combine(rutaAplicacion, "Archivos", "vacunas.txt");

            try
            {

                using (StreamReader sr = File.OpenText(rutaArchivoVacunas))
                {
                    List<string> vacunas = new List<string>();

                    bool paseHeader = false;
                    string linea = sr.ReadLine();
                    while (!string.IsNullOrEmpty(linea))
                    {
                        if (paseHeader)
                        {
                            vacunas.Add(linea);
                        }
                        Console.WriteLine(linea);
                        linea = sr.ReadLine();
                        paseHeader = true;
                    }
                    sr.Close();

                    foreach (string v in vacunas)
                    {
                        string[] stringSplit = v.Split(new string[] { "|" }, StringSplitOptions.None);

                        Vacunas vac = new Vacunas()
                        {
                            Id = Int32.Parse(stringSplit[0]),
                            Nombre = stringSplit[1],
                            Estatus = "",
                            CantDosis = Int32.Parse(stringSplit[4]),
                            LapsoEntreDosisDias = Int32.Parse(stringSplit[5]),
                            EdadMin = Int32.Parse(stringSplit[6]),
                            EdadMax = Int32.Parse(stringSplit[7]),
                            EficaciaCovid = Double.Parse(stringSplit[8]),
                            PrevenirHospitalizacion = Double.Parse(stringSplit[9]),
                            PrevenirCTI = Double.Parse(stringSplit[10]),
                            TempMin = double.Parse(stringSplit[11]),
                            TempMax = double.Parse(stringSplit[12]),
                            FaseClinica = Int32.Parse(stringSplit[13]),
                            Emergencia = (stringSplit[14] == "1") ? true : false,
                            Efectos = stringSplit[15],
                            Precio = Double.Parse(stringSplit[16]),
                            CantDosisProd = Int32.Parse(stringSplit[17]),
                            Covax = (stringSplit[18] == "1") ? true : false,
                            UsuarioRegistro = stringSplit[19],
                            UsuarioEdit = stringSplit[20],
                            FechaEdit = DateTime.Parse(stringSplit[21])
                        };

                        string[] estatusSplit = stringSplit[3].Split(new string[] { "," }, StringSplitOptions.None);

                        Array.Sort(estatusSplit, StringComparer.InvariantCulture);

                        foreach(string s in estatusSplit)
                        {
                            if(vac.Estatus == "")
                            {
                                vac.Estatus += s;
                            }
                            else
                            {
                                vac.Estatus += "," + s;
                            }
                        }

                        var codigoTipoVac = stringSplit[2];

                        TipoVacuna tipoVac = dbContext.TipoVacunas.FirstOrDefault(x => x.Cod == codigoTipoVac);

                        if (tipoVac != null) vac.Tipo = tipoVac;

                        Vacunas existeVac = dbContext.Vacunas.FirstOrDefault(x => x.Id == vac.Id || x.Nombre.ToUpper() == vac.Nombre.ToUpper());

                        if (existeVac == null)
                        {
                            dbContext.Vacunas.Add(vac);
                            dbContext.SaveChanges();
                        }
                    }

                    Console.WriteLine("Vacunas Importadas.");

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }



        public bool ImportarLabVac()
        {
            string rutaAplicacion = AppDomain.CurrentDomain.BaseDirectory;

            string rutaArchivoVacunas = Path.Combine(rutaAplicacion, "Archivos", "laboratoriosVacuna.txt");

            try
            {

                using (StreamReader sr = File.OpenText(rutaArchivoVacunas))
                {
                    List<string> laboratoriosVacuna = new List<string>();

                    bool paseHeader = false;
                    string linea = sr.ReadLine();
                    while (!string.IsNullOrEmpty(linea))
                    {
                        if (paseHeader)
                        {
                            laboratoriosVacuna.Add(linea);
                        }
                        Console.WriteLine(linea);
                        linea = sr.ReadLine();
                        paseHeader = true;
                    }
                    sr.Close();

                    foreach (string lv in laboratoriosVacuna)
                    {
                        string[] stringSplit = lv.Split(new string[] { "|" }, StringSplitOptions.None);

                        vacunaLab vacLab = new vacunaLab();

                        var codigoVac = Int32.Parse(stringSplit[1]);
                        var codigoLab = Int32.Parse(stringSplit[2]);

                        Vacunas vac = dbContext.Vacunas.Find(codigoVac);
                        Laboratorios lab = dbContext.Laboratorios.Find(codigoLab);

                        if (vac != null && lab != null)
                        {
                            vacLab.Id = Int32.Parse(stringSplit[0]);
                            vacLab.VacunaId = vac.Id;
                            vacLab.LaboratorioId = lab.Id;

                            vacunaLab existeVacLab = dbContext.VacunaLabs.FirstOrDefault(x => x.Id == vacLab.Id || (x.VacunaId == vacLab.VacunaId && x.LaboratorioId == vacLab.LaboratorioId));
                            
                            if ( existeVacLab == null)
                            {
                                dbContext.VacunaLabs.Add(vacLab);
                                dbContext.SaveChanges();
                            }
                        }
                    }

                    Console.WriteLine("Vacunas Importadas.");

                    return true;
                }
            }
            catch
            {
                throw;
                //return false;
            }
        }



    }
}
