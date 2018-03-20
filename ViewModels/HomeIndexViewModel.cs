using FirstCoreApp.Models;
using System.Collections.Generic;

namespace FirstCoreApp.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string GreetingMessage { get; set; }
    }
}
