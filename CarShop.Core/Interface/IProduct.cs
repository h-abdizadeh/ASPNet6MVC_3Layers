
using CarShop.Database.Models;
using Microsoft.AspNetCore.Http;

namespace CarShop.Core.Interface;

public interface IProduct : IDisposable
{
    Task<List<Product>> GetProducts(bool? notShow = null);

    Task<Product> GetProduct(Guid productId);

    Task<bool> AddProduct(Product product,IFormFile productImg);

    Task<bool> EditProduct(Product product);

    Task<bool> DeleteProduct(Guid productId);
}
