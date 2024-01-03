using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using CursoMVC.Models;
using CursoMVC.Models.TableViewModels;
using CursoMVC.Models.ViewModels;

namespace CursoMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> lst = null;
            using (curso_mvcEntities db = new curso_mvcEntities())
            {
                lst = (from d in db.user
                       where d.idState == 1
                       orderby d.email
                       select new  UserTableViewModel
                       {
                           Email = d.email,
                           Id = d.id,
                           Edad = d.edad

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

            if (!ModelState.IsValid) // Si no es valido
            {
                return View(model); // Nos retorna la vista de nuevo, pero con los valores que se rellanaron anteriormente
            }

            // Guardar en la base de datos
            using (var db = new curso_mvcEntities())
            {
                user oUser = new user();
                oUser.idState = 1;
                oUser.email = model.Email;
                oUser.edad = model.Edad;    
                oUser.password = model.Password;

                db.user.Add(oUser);

                db.SaveChanges();
            
            }

            return Redirect(Url.Content("~/User/"));

        }

        public ActionResult Edit(int Id) 
        {
            EditUserViewModel model = new EditUserViewModel();

            using (var db = new curso_mvcEntities())
            {
                var oUser = db.user.Find(Id);
                model.Edad = (int)oUser.edad;
                model.Email = oUser.email;
                model.Id = oUser.id;
            }
        

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new curso_mvcEntities())
            {
                var oUser = db.user.Find(model.Id);
                oUser.email = model.Email;
                oUser.edad = model.Edad;

                if (model.Password != null && model.Password.Trim() != "")
                {
                    oUser.password = model.Password;
                }

                // Se le dice al Entity que ese registró se editó:
                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }


            return Redirect(Url.Content("~/User/"));
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            using (var db = new curso_mvcEntities())
            {
                var oUser = db.user.Find(Id);
                oUser.idState = 3; // Eliminado logico

                // Se le dice al Entity el cambio realizado:
                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

            return Content("1");
        }

    }
}