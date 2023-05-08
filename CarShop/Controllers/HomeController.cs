using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
