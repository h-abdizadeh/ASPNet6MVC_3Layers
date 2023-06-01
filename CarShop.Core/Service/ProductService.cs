
using CarShop.Core.Interface;
using CarShop.Database.Context;
using CarShop.Database.Models;
using Microsoft.AspNetCore.Http;

using static System.Console;
using static System.ConsoleColor;

namespace CarShop.Core.Service;

public class ProductService : IProduct
{
    private readonly DatabaseContext _context;

    public ProductService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<bool> AddProduct(Product product, IFormFile productImg)
    {
        try
        {
            //save(upload) product image
            //1
            int imgCode = new Random().Next(10000, 100000);
            string imgName = imgCode + productImg.FileName;

            //2
            string imgPath = "wwwroot/image/product";
            //if imgPath directory not exists
            if (!Directory.Exists(imgPath))
                Directory.CreateDirectory(imgPath);

            //3
            string savePath = Path.Combine(imgPath, imgName);
            using (Stream stream = new FileStream(savePath, FileMode.Create))
            {
                await productImg.CopyToAsync(stream);
            }

            //add product to database (products table)
            product.Img = imgName;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return await Task.FromResult(true);
        }
        catch (Exception error)
        {
            WriteLine(error.Message,
                      BackgroundColor = Red,
                      ForegroundColor = Yellow);

            return await Task.FromResult(false);
        }
    }

    public Task<bool> DeleteProduct(Guid productId)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        if (_context != null)
        {
            _context.Dispose();
        }
    }

    public Task<bool> EditProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetProduct(Guid productId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Product>> GetProducts(bool? notShow = null)
    {
        var products = _context.Products.ToList();

        if (notShow != null)
        {
            return await Task.FromResult(products.Where(p => p.NotShow == notShow).ToList());
        }

        return await Task.FromResult(products);
    }
}
