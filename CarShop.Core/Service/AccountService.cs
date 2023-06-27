
using CarShop.Core.Interface;
using CarShop.Core.ViewModels;
using CarShop.Database.Classes;
using CarShop.Database.Context;
using CarShop.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Core.Service;

public class AccountService : IAccount
{
    private readonly DatabaseContext _context;

    public AccountService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<bool> AddUser(RegisterViewModel register)
    {
        try
        {

            ///user mobile exists or not
            var user =
                await _context.Users
                .FirstOrDefaultAsync(u => u.Mobile == register.Mobile);
            if (user != null) return false;


            ///add new user
            User newUser = new User()
            {
                Id = Guid.NewGuid(),
                RoleId = _context.Roles.SingleOrDefault(r => r.RoleName=="user").Id,

                Mobile = register.Mobile,
                Password = await new Security().HashPassword(await new Security().HashPassword(register.Password)),
                IsActive = true
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception error)
        {
            Console.WriteLine("addUser error : {0}", error.Message);
            return false;
        }
    }

    public void Dispose()
    {
        if (_context!=null)
        {
            _context.Dispose();
        }
    }
}
