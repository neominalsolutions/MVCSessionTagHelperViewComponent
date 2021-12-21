using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCSessionTagHelperViewComponent.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSessionTagHelperViewComponent.Controllers
{
    // [Authorize]
    // Bu controller'a sadece login olan erişebilir.
    // eğer login değilsek login sayfasına sistem otomatik olarak yönlendirecektir.
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

      
        public IActionResult Index()
        {
            return View();
        }

        // cookie üzerindeki bilgilerden çalışır
        // ilgili method üzerine bu attribute konulduğunda rol kontrolü yapar
        // istek tamamlanamazsa access denied sayfasına yönlendirir. 
        [Authorize(Roles = "Admin")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
