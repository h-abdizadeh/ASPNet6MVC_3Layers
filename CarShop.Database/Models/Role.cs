using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShop.Database.Models;

public class Role
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Display(Name ="کد نقش")]
    public Guid Id { get; set; }

    [Required]
    [Display(Name ="نام نقش")]
    public string RoleName { get; set; }//en

    [Required]
    [Display(Name = "عنوان نقش")]
    public string RoleTitle { get; set; }//fa


    //role -> user : n
    public virtual ICollection<User> Users { get; set; }
}
