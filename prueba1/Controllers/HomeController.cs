using prueba1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prueba1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var facultades = new List<Facultad>() {
                new Facultad()
                {
                    Id = 1,
                    Nombre = "Facultad Regional Tucumán"
                }
            };
            return View(facultades);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}