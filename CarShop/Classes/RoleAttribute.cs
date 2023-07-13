using CarShop.Database.Context;
using CarShop.Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarShop.Classes;

public class RoleAttribute : AuthorizeAttribute, IAuthorizationFilter
{

    private readonly string _roleName;

    public RoleAttribute(string roleName)
    {
        _roleName = roleName;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var identity = context.HttpContext.User.Identity;

        if (identity.IsAuthenticated)
        {
            var userMobile = identity.Name;

            DatabaseContext _context = new DatabaseContext();
            var user =
                _context.Users.FirstOrDefault(u => u.Mobile == userMobile && u.Role.RoleName == _roleName);

            if (user == null)
            {
                context.Result = new RedirectResult("~/account/login");
            }

        }
        else
        {
            context.Result = new RedirectResult("~/account/login");
        }
    }
}
