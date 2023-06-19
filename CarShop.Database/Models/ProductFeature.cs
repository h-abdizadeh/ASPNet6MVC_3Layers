
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CarShop.Database.Models;

public class ProductFeature
{
    [Key]
    public int Id { get; set; }

    [Required]
    public Guid ProductId { get; set; }

    [Required]
    public int FeatureId { get; set; }

    [Required]
    public string Value { get; set; }


    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }

    [ForeignKey("FeatureId")]
    public virtual Feature Feature { get; set; }
}
