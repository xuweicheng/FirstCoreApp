using System.Collections.Generic;
using System.Linq;
using FirstCoreApp.Models;

namespace FirstCoreApp.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "My Cozy Place" },
                new Restaurant { Id = 2, Name = "Cactus" },
                new Restaurant { Id = 3, Name = "Ramen House" },
            };
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);

        }

        public Restaurant GetOne(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant restaurant)
        {
            throw new System.NotImplementedException();
        }
    }
}
