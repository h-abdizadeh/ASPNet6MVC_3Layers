using CarShop.Core.Interface;
using CarShop.Database.Models;
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

        ViewBag.ProductId = Guid.NewGuid();

        return View();
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Create(Product product, IFormFile productImg)
    {

        if (ModelState.IsValid && productImg != null)
        {
            if (await _product.AddProduct(product, productImg))
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("img", "خطا در ثبت محصول");
        }

        ViewBag.GroupId =
          new SelectList(await _group.GetGroups(), "Id", "GroupName");

        ViewBag.ProductId = Guid.NewGuid();

        return View(product);
    }

    public async Task<IActionResult> Delete(Guid id)//id=>productId
    {
        var product = await _product.GetProduct(id);

        if (product == null)
        {
            return RedirectToAction(nameof(Index));
        }

        return PartialView(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Product product)
    {
        await _product.DeleteProduct(product.Id);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> IndexFeature()
    {
        var featurs = await _product.GetFeatures();
        return View(featurs);
    }
    public IActionResult AddFeature()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddFeature(Feature feature)
    {
        if (ModelState.IsValid)
        {
            if (await _product.AddFeature(feature))
            {
                return RedirectToAction(nameof(IndexFeature));
            }
        }

        return View(feature);
    }

    public async Task<IActionResult> CreateProductFeature(Guid id)
    {
        ViewBag.ProductFeatures = await _product.GetProductFeatures(id);

        ViewBag.ProductId = id;

        var features = await _product.GetFeatures();
        ViewBag.FeatureId = new SelectList(features, "Id", "Title");

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateProductFeature(ProductFeature productFeature)
    {
        if (await _product.AddProductFeature(productFeature))
            return RedirectToAction("CreateProductFeature",
                                     new { id = productFeature.ProductId });


        ViewBag.ProductFeatures =
            await _product.GetProductFeatures(productFeature.ProductId);
        return View(productFeature);
    }


}
