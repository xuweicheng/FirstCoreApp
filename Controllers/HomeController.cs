using FirstCoreApp.Models;
using FirstCoreApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreApp{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        
        public IActionResult Index()
        {
            var model = _restaurantData.GetAll();
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