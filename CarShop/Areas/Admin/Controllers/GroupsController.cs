using Microsoft.AspNetCore.Mvc;
using CarShop.Core.Interface;

namespace CarShop.Areas.Admin.Controllers;

[Area("Admin")]
public class GroupsController : Controller
{
    private IGroup _group;
    public GroupsController(IGroup group)
    {
        _group = group;
    }

    public async Task<IActionResult> Index()
    {
        var groups = await _group.GetGroups();
        return View(groups);
    }

    public async Task<IActionResult> Details(int id)
    {
        var group = await _group.GetGroup(id);

        if (group != null)
        {
            return View(group);
        }

        //return NotFound();
        return RedirectToAction(nameof(Index));
    }
}
