using CarShop.Core.Interface;
using CarShop.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers;

[Authorize]
public class ProfileController : Controller
{

    IProfile _profile;

    public ProfileController(IProfile profile)
    {
        _profile = profile;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _profile.GetUser(userMobile: User.Identity.Name);

        if (user.Role.RoleName == "admin")
            return Redirect("~/admin/panel");


        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<Guid> AddToShoppingCart(ShoppingViewModel shopping)
    {
        var factorId=await _profile.AddShopping(shopping);

        return factorId;
    } 
}
