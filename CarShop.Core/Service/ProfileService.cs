

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

    public async Task<Factor> AddShopping(ShoppingViewModel shopping)
    {

        //1
        //user factor where isPay==false
        var factor = await _context.Factors.
                            Include(f => f.FactorDetails).
                            FirstOrDefaultAsync(f => 
                            f.UserId == shopping.UserId && !f.IsPay);

        //2
        //create new factor where factor==null 
        if (factor==null)
        {
            Factor newFactor = new Factor()
            {
                Id = Guid.NewGuid(),
                UserId = shopping.UserId,
                //OpenDateTime=

            };
        }

        return null;
    }

    public async void Dispose()
    {
        if (_context != null)
        {
            await _context.DisposeAsync();
        }
    }
}
