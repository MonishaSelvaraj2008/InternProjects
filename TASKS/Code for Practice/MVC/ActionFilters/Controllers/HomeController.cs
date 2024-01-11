using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ActionFilters.Models;
using ActionFilters.Data;

namespace ActionFilters.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    //[CustomActionFilter]
    public IActionResult Index()
    {
        int[] x = new int[2];
        x[1] = 100;
        return View();
    }

    public ViewResult Welcome()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
