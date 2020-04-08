using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{ID=1, Name="J'Pizza", Location="Buzau", Cuisine=CuisineType.International},
                new Restaurant{ID=2, Name="Am Rosenanger", Location="Brasov", Cuisine=CuisineType.German},
                new Restaurant{ID=3, Name="Dei frati", Location="Brasov", Cuisine=CuisineType.Italian}
            };
        }

        public IEnumerable<Restaurant> GetReastaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;

        }

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.FirstOrDefault(x => x.ID == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.ID = restaurants.Max(r => r.ID) + 1;

            return newRestaurant;
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var updatedRestaurant = restaurants.FirstOrDefault(r => r.ID == restaurant.ID);
            if (updatedRestaurant != null)
            {
                updatedRestaurant.Name = restaurant.Name;
                updatedRestaurant.Location = restaurant.Location;
                updatedRestaurant.Cuisine = restaurant.Cuisine;
            }
            return updatedRestaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.ID == id);
            if (restaurant !=null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }
    }
}
