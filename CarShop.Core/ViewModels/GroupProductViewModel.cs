﻿
using CarShop.Database.Models;

namespace CarShop.Core.ViewModels;

public class GroupProductViewModel
{
    public IEnumerable<Group>? Groups { get; set; } = null;
    public IEnumerable<Product>? Products { get; set; } = null;
}
