using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace CarShop.Database.Models;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }

    [Display(Name ="گروه")]
    [Required(ErrorMessage ="انتخاب گروه محصول الزامیست")]
    public int GroupId { get; set; }

    [Display(Prompt="نام محصول")]
    [Required(ErrorMessage = "درج نام محصول الزامیست")]
    [MaxLength(25)]
    public string ProductName { get; set; }

    [Display(Prompt = "درباره محصول")]
    [MaxLength(125)]
    public string? Des  { get; set; }

    [Display(Prompt = "تصویر محصول")]
    [Required(ErrorMessage ="بارگزاری تصویر الزامیست")]
    public string Img { get; set; }

    [Display(Name  = "قیمت محصول",Prompt = "قیمت محصول")]
    [Required(ErrorMessage = "درج قیمت الزامیست")]
    public int Price  { get; set; }

    [Display(Name = "موجودی",Prompt = "موجودی")]
    [Required(ErrorMessage = "درج تعداد موجودی الزامیست")]
    public int Inventory  { get; set; }

    [Display(Name = "درصد تخفیف",Prompt = "درصد تخفیف")]
    public int SellOff { get; set; } = 0;

    [Display(Name = "عدم نمایش")]
    public bool NotShow { get; set; } = false;

    [ForeignKey("GroupId")]
    public virtual Group Group { get; set; }

}
