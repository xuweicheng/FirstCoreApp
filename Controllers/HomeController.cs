using FirstCoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreApp{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new Restaurant { Id = 1, Name = "My Cozy Place" };
            return View(model);
        }

        //public IActionResult Index()
        //{
        //    var model = new Restaurant { Id = 1, Name = "My Cozy Place" };
        //    return new ObjectResult(model);
        //}
        //public string Index()
        //{
        //    return "Hello from HomeController";
        //}
        
    }
}