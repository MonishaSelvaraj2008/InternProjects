using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AllStateManagement.Models;

namespace AllStateManagement.Controllers
{
    public class WelcomeController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetString("Name", "Josh");
            HttpContext.Session.SetInt32("Age",32);
            return View();
        }

        public IActionResult Get()
        {
            User newUser = new User()
            {
                Name = HttpContext.Session.GetString("Name"),
                Age = HttpContext.Session.GetInt32("Age").Value
            };
            return View(newUser);
        }

        public IActionResult GetQueryString(string name, int age)
        {
            User newUser = new User()
            {
                Name = name,
                Age = age
            };
            return View(newUser);
        }

        public IActionResult SetHiddenFieldValue()
        {
            User newUser = new User()
            {
                Id = 101,
                Name = "Isha",
                Age = 21
            };
            return View(newUser);
        }
    }
}
