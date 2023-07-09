
using CarShop.Core.Interface;
using CarShop.Core.ViewModels;
using CarShop.Database.Classes;
using CarShop.Database.Context;
using CarShop.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Claims;

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
                RoleId = _context.Roles.SingleOrDefault(r => r.RoleName == "user").Id,

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
        if (_context != null)
        {
            _context.Dispose();
        }
    }

    public async Task<User> loginUser(LoginViewModel login)
    {
        try
        {
            var hashPassword =
                await new Security().HashPassword(await new Security().HashPassword(login.Password));

            var user =
                await _context.Users.Include(u => u.Role)
                          .FirstOrDefaultAsync(u => u.Mobile == login.Mobile
                          && u.Password == hashPassword);

            if (user != null) return user;
          
            return null;
        }
        catch (Exception)
        {

            return null;
        }
    }
}
