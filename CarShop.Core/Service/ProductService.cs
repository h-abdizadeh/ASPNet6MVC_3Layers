
using CarShop.Core.Interface;
using CarShop.Database.Context;
using CarShop.Database.Models;
using Microsoft.AspNetCore.Http;

namespace CarShop.Core.Service;

public class ProductService : IProduct
{
    private readonly DatabaseContext _context;

    public ProductService(DatabaseContext context)
    {
        _context = context;
    }

    public Task<bool> AddProduct(Product product, IFormFile productImg)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProduct(Guid productId)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        if (_context!=null)
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

        if (notShow!=null)
        {
            return await Task.FromResult(products.Where(p => p.NotShow == notShow).ToList());
        }

        return await Task.FromResult(products);
    }
}
