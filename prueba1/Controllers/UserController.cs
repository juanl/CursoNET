using prueba1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prueba1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrarse(UsuarioRegistroViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                //cosas que deberíamos hacer y después ...
                return View("RegistroExitoso");
            }
            else
            {
                return View(usuario);
            }
        }

        public JsonResult UserNameAvailable(string nombre)
        {
            var rnd = new Random();
            var valor = rnd.Next(1,100);
            if (valor > 80)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public JsonResult GetPartidoByIdProvincia(int IdProvincia)
        {
            var items = new List<SelectListItem>()
            { new SelectListItem

            {

                Text = "San Miguel de Tucumán",
                Value = "53",

            },
            new SelectListItem

            {

                Text = "Alberdi",

                Value = "54",

            },
            new SelectListItem

            {

                Text = "Simoca",

                Value = "55",

            },
            };
            return Json(items, JsonRequestBehavior.AllowGet);
        }
    }
}
