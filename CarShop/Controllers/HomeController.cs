using CarShop.Core.Interface;
using CarShop.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers;

public class HomeController : Controller
{
    IGroup _group;
    IProduct _product;
    IProfile _profile;
    public HomeController(IGroup group, IProduct product,IProfile profile)
    {
        _group = group;
        _product = product;
        _profile = profile;
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

        ShoppingViewModel shopping = new ShoppingViewModel()
        {
            UserId = (await _profile.GetUser(User.Identity.Name)).Id,
            ProductId = product.Id,
        };

        ProductInfoViewModel productInfo = new ProductInfoViewModel()
        {
            ProductInfo = product,
            Shopping = shopping
        };

        //ViewBag.RelatedProducts = await _product.GetProducts(id);
        ViewData["RelatedProducts"] = await _product.GetProducts(id);
        ViewBag.ProductFeatures = await _product.GetProductFeatures(id);

        return View(product);
    }
}
