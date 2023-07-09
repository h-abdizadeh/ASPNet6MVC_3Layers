using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class PanelController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}
