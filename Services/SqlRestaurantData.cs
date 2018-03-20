using System;
using System.Collections.Generic;
using System.Linq;
using FirstCoreApp.Data;
using FirstCoreApp.Models;

namespace FirstCoreApp.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private MyDbContext _context;

        public SqlRestaurantData(MyDbContext context)
        {
            _context = context;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            _context.Restaurants.Add(newRestaurant);
            _context.SaveChanges();

            return newRestaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.OrderBy(r => r.Name);
        }

        public Restaurant GetOne(int id)
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }
    }
}
