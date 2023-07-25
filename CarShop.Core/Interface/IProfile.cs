using CarShop.Core.ViewModels;
using CarShop.Database.Models;

namespace CarShop.Core.Interface;

public interface IProfile:IDisposable
{
    Task<Guid> AddShopping(ShoppingViewModel shopping);//return factorId
}
