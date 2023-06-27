using CarShop.Core.Interface;
using CarShop.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers
{
    public class AccountController : Controller
    {
        IAccount _account;
        public AccountController(IAccount account)
        {
            _account = account;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                if (await _account.AddUser(register))
                {
                    return RedirectToAction(nameof(Login));
                }

                ModelState.AddModelError("RePassword", "احتمالا این شماره موبایل پیش از این ثبت شده است");
                return View(register);
            }

            return View(register);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}
