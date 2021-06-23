using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos.Repositorios;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string mensaje, string alerta)
        {
            
            if (Session["User"] == null)
            {
                if (mensaje != "")
                {
                    ViewBag.Mensaje = mensaje;
                }
                if (alerta != "")
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