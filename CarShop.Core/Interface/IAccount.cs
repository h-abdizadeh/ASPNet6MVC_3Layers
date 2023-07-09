

using CarShop.Core.ViewModels;
using CarShop.Database.Models;

namespace CarShop.Core.Interface;

public interface IAccount:IDisposable
{
    Task<bool> AddUser(RegisterViewModel register);
    Task<User> loginUser(LoginViewModel login);
}
