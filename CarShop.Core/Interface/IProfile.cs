using CarShop.Core.ViewModels;
using CarShop.Database.Models;

namespace CarShop.Core.Interface;

public interface IProfile:IDisposable
{
    Task<User> GetUser(string userMobile);
    Task<Guid> AddShopping(ShoppingViewModel shopping);//return factorId
}
