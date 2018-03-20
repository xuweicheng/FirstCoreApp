using FirstCoreApp.Models;
using FirstCoreApp.Services;
using FirstCoreApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreApp
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData,
            IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel
            {
                Restaurants = _restaurantData.GetAll(),
                GreetingMessage = _greeter.getGreetingOfToday()
            };

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.GetOne(id);

            if (model == null)
            {
                //other options
                //return RedirectToAction()
                //return NotFound(), where NotFound implements IActionResult
                //return View("RestaurantNotFound");
                return RedirectToAction(nameof(Index));
            }

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