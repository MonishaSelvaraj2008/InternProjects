using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace FirstApp.Controllers
{
    public class EmployeeController :Controller
    {
        public IActionResult Index()
        {
            return View(Repository.AllEmployees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            Repository.Create(employee);
            return View("Thanks",employee);
        }
    }
}