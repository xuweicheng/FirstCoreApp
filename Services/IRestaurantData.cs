using FirstCoreApp.Models;
using System.Collections.Generic;

namespace FirstCoreApp.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }
}
