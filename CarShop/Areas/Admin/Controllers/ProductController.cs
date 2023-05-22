using CarShop.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Areas.Admin.Controllers;

[Area("admin")]
public class ProductController : Controller
{
    IProduct _product;
    public ProductController(IProduct product)
    {
        _product = product;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _product.GetProducts();
        return View(products);
    }
}
