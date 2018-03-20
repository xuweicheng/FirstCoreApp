using FirstCoreApp.Models;
using FirstCoreApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstCoreApp.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private IRestaurantData _restaurantData;

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public EditModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public void OnGet(int id)
        {
            Restaurant = _restaurantData.GetOne(id);
        }
        
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            _restaurantData.Update(Restaurant);
            return RedirectToAction("Index", "Home");
        }
    }
}