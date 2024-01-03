using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoMVC.Controllers
{
    public class CerrarController : Controller
    {
        public ActionResult Logoff() 
        {
            Session["User"] = null; // La sesion cambia a ser nula
            return RedirectToAction("Index", "Access"); // Lo mando al index del controlador Access
        }

    }
}