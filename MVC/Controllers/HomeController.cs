using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using MVC.Models;
using Datos.Repositorios;


namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public const string SessionCI = "";


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index(string mensaje, string alerta)
        {
            string a = HttpContext.Session.GetString(SessionCI);
            if (HttpContext.Session.GetString(SessionCI) == "" || HttpContext.Session.GetString(SessionCI) == null)
            {
                if (mensaje != "")
                {
                    ViewBag.Mensaje = mensaje;
                }
                if(alerta != "")
                {
                    ViewBag.Alerta = alerta;
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Usuarios");
            }

        }

        public ActionResult CargarDatos()
        {
            ImportarArchivos ia = new ImportarArchivos();
            if (ia.ImportarUsuarios())
            {
                if (ia.ImportarTipoVacunas())
                {
                    if (ia.ImportarLaboratorios())
                    {
                        if (ia.ImportarVacunas())
                        {
                            if (ia.ImportarLabVac())
                            {
                                return RedirectToAction("Index", "Home", new { mensaje = "Datos cargados" });
                            }
                            else
                            {
                                return RedirectToAction("Index", "Home", new { alerta = "Error al cargar Laboratorios a Vacunas" });
                            }
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { alerta = "Error al cargar Vacunas" });
                        }
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home", new { alerta = "Error al cargar Laboratorios" });
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { alerta = "Error al cargar Tipos de Vacuna" });
                }
            }
            else
            {
                return RedirectToAction("Index", "Home", new { alerta = "Error al cargar Usuarios" });
            }
        }


    }
}
