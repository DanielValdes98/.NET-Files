using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CursoMVC.Models;
using System.Web.Mvc;
using CursoMVC.Controllers;

namespace CursoMVC.Filters
{
    public class VerifySesion : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Para verificar que el usuario exista, se toma la variable de sesión:
            var oUser = (user)HttpContext.Current.Session["User"];

            if (oUser == null) { // Si es nulo
                if (filterContext.Controller is AccessController == false) // Si es diferente a AccessController
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index"); // Lo devuelve al login
                }
            } else
            {
                if (filterContext.Controller is AccessController == true) // Si es AccessController (estoy en sesion), no deje devolver al login
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index"); // Lo devuelve a la pagina principal
                }
            }
            base.OnActionExecuting(filterContext); // Le da acceso 
        }
    }
}