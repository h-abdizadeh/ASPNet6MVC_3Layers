using Microsoft.AspNetCore.Mvc;

namespace CarShop.Areas.Admin.Controllers;

[Area("Admin")]
public class PanelController : Controller
{
    public IActionResult Index()
    {

        return View();
    }
}
