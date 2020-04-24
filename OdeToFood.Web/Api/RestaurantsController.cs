using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OdeToFood.Web.Api
{
    public class RestaurantsController : ApiController
    {
        private readonly IRestaurantData restaurantDb;

        public RestaurantsController(IRestaurantData restaurantDb)
        {
            this.restaurantDb = restaurantDb;
        }
        public IEnumerable<Restaurant> Get()
        {
            var model = restaurantDb.GetAll();
            return model;
        }
    }
}
