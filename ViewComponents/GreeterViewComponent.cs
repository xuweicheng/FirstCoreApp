using FirstCoreApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreApp.ViewComponents
{
    public class GreeterViewComponent : ViewComponent
    {
        private IGreeter _greeter;

        public GreeterViewComponent(IGreeter greeter)
        {
            _greeter = greeter;
        }

        public IViewComponentResult Invoke()
        {
            var greeting = _greeter.getGreetingOfToday();
            return View("Default", greeting);
        }
    }
}
