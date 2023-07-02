using System.ComponentModel.DataAnnotations;

namespace CarShop.Core.ViewModels;

public class LoginViewModel
{
    [Display(Name = "mobile", Prompt = "شماره موبایل 11 رقمی")]
    [MaxLength(11, ErrorMessage = "شماره موبایل 11 رقمی")]
    [MinLength(11, ErrorMessage = "شماره موبایل 11 رقمی")]
    public string Mobile { get; set; }

    [Display(Name = "password", Prompt = "رمز عبور حداقل 8 کاراکتر")]
    [MinLength(8, ErrorMessage = "رمز عبور حداقل 8 کاراکتر")]
    [MaxLength(25, ErrorMessage = "رمز عبور حداکثر 25 کاراکتر")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
