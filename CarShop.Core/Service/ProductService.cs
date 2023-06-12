
using CarShop.Core.Interface;
using CarShop.Database.Context;
using CarShop.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using static System.Console;
using static System.ConsoleColor;

namespace CarShop.Core.Service;

public class ProductService : IProduct
{

    string imgPath = "wwwroot/image/product";

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

    public async Task<bool> DeleteProduct(Guid productId)
    {
        try
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                //1
                //delete product image 'file' from image directory
                var imgAddress = Path.Combine(imgPath, product.Img);
                if (File.Exists(imgAddress))
                {
                    File.Delete(imgAddress);
                }

                //2
                //remove product 'record' from products table (database)
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                return await Task.FromResult(true);
            }

            //product==null
            return await Task.FromResult(false);
        }
        catch (Exception error)
        {
            WriteLine(error.Message,
                      BackgroundColor = Red,
                      ForegroundColor = Yellow);

            return await Task.FromResult(false);

        }
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

    public async Task<Product> GetProduct(Guid productId)
    {
        var product = _context.Products.Find(productId);
        return await Task.FromResult(product);
    }

    public async Task<List<Product>> GetProducts(bool? notShow = null, int? sellOff = null)
    {
        var products = _context.Products.Include(p=>p.Group).ToList();

        if (sellOff!=null)
        {
            products = products.Where(p => p.SellOff >= sellOff).ToList();
        }

        if (notShow != null)
        {
            products= products.Where(p => p.NotShow == notShow).ToList();
        }

        return await Task.FromResult(products);
    }
}
