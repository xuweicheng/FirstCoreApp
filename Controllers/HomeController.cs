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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var newRestaurant = new Restaurant { Name = model.Name, Cuisine = model.Cuisine };

            newRestaurant = _restaurantData.Add(newRestaurant);

            //return RedirectToAction(nameof(Index));
            //return View("Details", newRestaurant); the url stays in Create, refresh will resubmit
            return RedirectToAction(nameof(Details), new { id = newRestaurant.Id });
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