using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace CarShop.Database.Models;

public class Group
{
    [Key]
    public int Id { get; set; }

    [Display(Name ="نام گروه")]
    [Required(ErrorMessage ="نام گروه الزامیست")]
    [MaxLength(20)]
    public string GroupName { get; set; }

    [Display(Name ="درباره گروه")]
    [MaxLength(100)]
    public string?  GroupDes { get; set; }

    [Display(Name = "عدم نمایش")]
    public bool NotShow { get; set; } = false;

    public virtual ICollection<Product>? Products { get; set; }

}
