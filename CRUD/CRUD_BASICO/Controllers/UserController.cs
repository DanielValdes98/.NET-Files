using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using CRUD_BASICO.Models;
using CRUD_BASICO.Models.TableViewModels;

namespace CRUD_BASICO.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModels> lst = null;

            // Instacia del modelo de la base de datos para hacer una conexion con la BD y hacer un objeto del modelo
            using (bd_pruebaEntities db = new bd_pruebaEntities())
            {
                lst = (from d in db.user
                       select new UserTableViewModels
                       {
                           Id = d.id,
                           Nombre = d.nombre,
                           Edad = d.edad,
                           Email = d.email
                       }).ToList();
            }

            return View(lst);
        }

        [HttpGet]
        public ActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserViewModel model) // Trae el modelo
        {
            if(!ModelState.IsValid) // Si no es valido
            {
                return View(model); // Nos retorna la vista de nuevo, pero con los valores que se rellanaron anteriormente
            }

            // Guardar en la BD
            using (bd_pruebaEntities db = new bd_pruebaEntities())
            {
                user oUser = new user();
                oUser.nombre = model.Nombre;
                oUser.edad = model.Edad;
                oUser.email = model.Email;

                db.user.Add(oUser);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));
        }

        public ActionResult Edit(int Id) 
        {
            EditUserViewModel model = new EditUserViewModel();

            using (bd_pruebaEntities db = new bd_pruebaEntities())
            {
                var oUser = db.user.Find(Id);
                model.Nombre = oUser.nombre;
                model.Edad = oUser.edad;
                model.Email = oUser.email;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (bd_pruebaEntities db = new bd_pruebaEntities())
            {
                var oUser = db.user.Find(model.Id);
                oUser.nombre = model.Nombre;
                oUser.edad = model.Edad;
                oUser.email = model.Email;

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));

        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            using (var db = new bd_pruebaEntities())
            {
                var oUser = db.user.Find(Id);
                db.user.Remove(oUser);

                db.SaveChanges();
            }

            return Content("1");
        }


    }
}