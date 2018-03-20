using FirstCoreApp.Models;
using System.Collections.Generic;

namespace FirstCoreApp.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant GetOne(int id);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Update(Restaurant restaurant);
    }
}
