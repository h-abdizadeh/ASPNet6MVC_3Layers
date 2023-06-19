﻿
using System.ComponentModel.DataAnnotations;

namespace CarShop.Database.Models;

public class Feature
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }
}
