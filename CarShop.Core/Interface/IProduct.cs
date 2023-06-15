
using CarShop.Core.Service;
using CarShop.Database.Models;
using Microsoft.AspNetCore.Http;

namespace CarShop.Core.Interface;

public interface IProduct : IDisposable
{
    Task<List<Product>> GetProducts(bool? notShow = null, int? sellOff = null);

    Task<Product> GetProduct(Guid productId);

    Task<List<Product>> GetProducts(Guid productId);//related product list

    Task<bool> AddProduct(Product product, IFormFile productImg);

    Task<bool> EditProduct(Product product);

    Task<bool> DeleteProduct(Guid productId);
}
