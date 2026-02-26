using Microsoft.AspNetCore.Mvc;
using CoreMvcDemo.Models;
namespace CoreMvcDemo.Controllers
{
    public class CityController : Controller
    {
        public IActionResult Index()
        {
            List<City> cities = new List<City>();
            cities.Add(new City { CityId = 1, CityName = "Pune" });
            cities.Add(new City { CityId = 2, CityName = "Mumbai" });
            cities.Add(new City { CityId = 3, CityName = "Nashik" });
            cities.Add(new City { CityId = 4, CityName = "Nagar" });
            cities.Add(new City { CityId = 5, CityName = "Delhi" });
            return View(cities);
        }
    }
}
