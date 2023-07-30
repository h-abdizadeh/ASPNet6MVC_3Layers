

using CarShop.Core.Classes;
using CarShop.Core.Interface;
using CarShop.Core.ViewModels;
using CarShop.Database.Context;
using CarShop.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Core.Service;

public class ProfileService : IProfile
{
    private readonly DatabaseContext _context;

    public ProfileService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Guid> AddShopping(ShoppingViewModel shopping)
    {
        //1
        //find product by Id
        var product =
            await _context.Products.FindAsync(shopping.ProductId);

        if (product == null) return Guid.Empty;
        var price =
    product.Price - (product.Price * product.SellOff / 100);


        //2
        //user factor where isPay==false
        var factor = await _context.Factors.
                            Include(f => f.FactorDetails).
                            FirstOrDefaultAsync(f =>
                            f.UserId == shopping.UserId && !f.IsPay);
        try
        {
            //3
            //create new factor where factor==null 
            if (factor == null)
            {
                Factor newFactor = new Factor()
                {
                    Id = Guid.NewGuid(),
                    UserId = shopping.UserId,
                    OpenDateTime = await new CoreClass().GetPersianDate(),
                    IsPay = false,
                    Status = "در انتظار پرداخت",
                };

                await _context.Factors.AddAsync(newFactor);

                //create newFactor detail
                FactorDetail newDetail = new FactorDetail()
                {
                    FactorId = newFactor.Id,
                    ProductId = product.Id,
                    DetailCount = 1,
                    DetailPrice = price * 1,//price * detailCount
                };

                await _context.FactorDetails.AddAsync(newDetail);
                await _context.SaveChangesAsync();

                return newFactor.Id;
            }

            //3
            //update existing factor
            var detail =
                factor.FactorDetails.FirstOrDefault(d => d.ProductId == shopping.ProductId);

            //add detail in existing factor
            if (detail == null)
            {
                FactorDetail newDetail = new FactorDetail()
                {
                    FactorId = factor.Id,
                    ProductId = product.Id,
                    DetailCount = 1,
                    DetailPrice = price * 1,//price * detailCount
                };

                await _context.FactorDetails.AddAsync(newDetail);
                await _context.SaveChangesAsync();

                return factor.Id;         
            }

            //update existing factorDetail in existing factor
            detail.DetailCount += 1;
            detail.DetailPrice = price * detail.DetailCount;

            await _context.SaveChangesAsync();
            return factor.Id;


        }
        catch (Exception error)
        {
            Console.WriteLine("add shopping error ===> {0}", error.Message);
            return Guid.Empty;
        }

    }

    public async void Dispose()
    {
        if (_context != null)
        {
            await _context.DisposeAsync();
        }
    }

    public async Task<User> GetUser(string userMobile)
    {
        var user = await _context.Users.Where(u => u.Mobile == userMobile).
             Select(s => new User()
             {
                 Id = s.Id,
                 Mobile = s.Mobile,
                 IsActive = s.IsActive,
                 Role = new Role()
                 {
                     Id = s.Role.Id,
                     RoleName = s.Role.RoleName
                 }
             }).FirstOrDefaultAsync();

        return user;
    }
}
