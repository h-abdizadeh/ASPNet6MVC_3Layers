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


        //all products by notShow=false and sellOff>=1
        var products =
            (await _product.GetProducts(notShow: false, sellOff: 1)).Take(4);

        GroupProductViewModel viewModel = new GroupProductViewModel()
        {
            Groups = groups,
            Products = products
        };

        return View(viewModel);
    }

    public async Task<IActionResult> Products()
    {
        var products = await _product.GetProducts(false);
        return View(products);
    }

    public async Task<IActionResult> ProductInfo(Guid id)//id ==> productId
    {
        var product = await _product.GetProduct(id);

        //ViewBag.RelatedProducts = await _product.GetProducts(id);
        ViewData["RelatedProducts"] = await _product.GetProducts(id);
        ViewBag.ProductFeatures = await _product.GetProductFeatures(id);

        return View(product);
    }
}
