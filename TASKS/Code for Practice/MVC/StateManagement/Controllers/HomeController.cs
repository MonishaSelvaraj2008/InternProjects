using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StateManagement.Models;

namespace StateManagement.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    int EmployeeID;
    string EmployeeName;
    int Age;

    
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index1()
    {
        ViewBag.Data=TempData["EmployeeName"].ToString();
        return View();
    }
    public IActionResult Index()
    {
       ViewData["Message"] = "Welcome to MVC Architecture";
        

        //ViewData["Employee"] = EmployeeList;
      //  ViewBag.name="HARI KRISHNA";
        //TempData["EmployeeName"]="Srinika";
        return RedirectToAction("Index1");
    }

    public IActionResult Privacy()
    {
        
        IList<string> EmployeeList = new List<string>();
        EmployeeList.Add("Monisha");
        EmployeeList.Add("Sandhiya");
        EmployeeList.Add("Vedha");

        ViewBag.Employee=EmployeeList;

        ViewBag.TotalEmployee=EmployeeList.Count();
        ViewData["name"] = "Dhari";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
