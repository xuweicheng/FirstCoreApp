using FirstCoreApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstCoreApp.Pages
{
    public class GreetingModel : PageModel
    {
        private IGreeter _greeter;
        public string Greeting { get; set; }

        public GreetingModel(IGreeter greeter)
        {
            _greeter = greeter;
        }

        public void OnGet(string name)
        {
            Greeting = $"{name} : {_greeter.getGreetingOfToday()}";
        }
    }
}
