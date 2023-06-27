

using CarShop.Core.ViewModels;

namespace CarShop.Core.Interface;

public interface IAccount:IDisposable
{
    Task<bool> AddUser(RegisterViewModel register);
}
