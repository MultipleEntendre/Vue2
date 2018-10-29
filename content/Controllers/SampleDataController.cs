using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Vue2Spa.Models;

namespace Vue2Spa.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {   

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("[action]")]
        public IEnumerable<User> Users()
        {
            using (BloggingContext context = new BloggingContext())
            {

                var users = context.User.ToList();

                return users;
            }
        }

        [HttpPut("[action]")]
        public User SaveUser([FromBody]User user)
        {

            using (BloggingContext db = new BloggingContext())
            {
                var mod = db.User.First(x => x.ID == user.ID);
                mod.Name = user.Name;
                mod.Address = user.Address;
                mod.Age = user.Age;
                db.SaveChanges();

                return user;
            }
        }

        [HttpPut("[action]")]
        public User AddUser([FromBody]User user)
        {

            using (BloggingContext db = new BloggingContext())
            {
                db.User.Add(user);
                db.SaveChanges();

                return user;
            }
        }
    }
}
