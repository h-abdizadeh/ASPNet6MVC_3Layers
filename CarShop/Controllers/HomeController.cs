using CarShop.Core.Interface;
using CarShop.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers;

public class HomeController : Controller
{
    IGroup _group;
    IProduct _product;
    public HomeController(IGroup group, IProduct product)
    {
        _group = group;
        _product = product;
    }

    public async Task<IActionResult> Index()
    {
        var groups =
            (await _group.GetGroups(/*notShow:*/false)).Take(4);

        var products =
            (await _product.GetProducts(false)).Take(4);

        GroupProductViewModel viewModel = new GroupProductViewModel()
        {
            Groups = groups,
            Products = products
        };

        return View(viewModel);
    }
}
