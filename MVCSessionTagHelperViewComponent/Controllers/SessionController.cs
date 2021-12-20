using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCSessionTagHelperViewComponent.Models;
using MVCSessionTagHelperViewComponent.SessionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSessionTagHelperViewComponent.Controllers
{


    public class SessionController : Controller
    {
   
        public IActionResult SetSession()
        {

            HttpContext.Session.SetString("deneme", HttpContext.Session.Id);
            HttpContext.Session.SetObject<Product>("ProductSession", new Product
            {
                Name = "P1",
                Description = "Deneme"
            });

            return View();
        }

        public IActionResult GetSession()
        {

          ViewBag.Session =   HttpContext.Session.GetString("deneme");


            ViewBag.SessionProduct = HttpContext.Session.GetObject<Product>("ProductSession");


            return View();
        }
    }
}
