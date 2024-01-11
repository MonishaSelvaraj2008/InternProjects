using Microsoft.AspNetCore.Mvc;

namespace AllStateManagement.Controllers
{
    public class ViewBagController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.UserId = 101;
            ViewBag.Name = "Monisha";
            ViewBag.Age = 21;

            return View();
        }
    }
}