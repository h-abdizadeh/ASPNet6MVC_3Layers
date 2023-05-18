using CarShop.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers;

public class HomeController : Controller
{
    IGroup _group;
    public HomeController(IGroup group)
    {
        _group = group;
    }

    public async Task<IActionResult> Index()
    {
        var groups = (await _group.GetGroups(/*notShow:*/false)).Take(4);

        return View();
    }
}
