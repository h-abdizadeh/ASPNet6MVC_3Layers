using CarShop.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarShop.Areas.Admin.Controllers;

[Area("admin")]
public class ProductController : Controller
{
    IProduct _product;
    IGroup _group;
    public ProductController(IProduct product, IGroup group)
    {
        _product = product;
        _group = group;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _product.GetProducts();
        return View(products);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.GroupId = 
            new SelectList(await _group.GetGroups(), "Id", "GroupName");
        return View();
    }
}
