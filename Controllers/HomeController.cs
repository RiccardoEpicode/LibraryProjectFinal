using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FinalVersion.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }

    }
}
