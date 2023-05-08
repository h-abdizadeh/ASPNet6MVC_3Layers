using CarShop.Database.Models;
using CarShop.Database.Classes;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Database.Context;

public class DbInitializer
{
    private ModelBuilder _modelBuilder;

    public DbInitializer(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    internal async void Seed()
    {
        Role adminRole = new Role()
        {
            Id = Guid.NewGuid(),
            RoleName = "admin",
            RoleTitle = "مدیر",
        };
        _modelBuilder.Entity<Role>().HasData(adminRole);

        Role userRole = new Role()
        {
            Id = Guid.NewGuid(),
            RoleName = "user",
            RoleTitle = "کاربر",
        };
        _modelBuilder.Entity<Role>().HasData(userRole);


        User adminUser = new User()
        {

            Id = Guid.NewGuid(),
            RoleId = adminRole.Id,
            Mobile = "09112223344",
            Password = await new Security().HashPassword("12345678"),
            IsActive = true,
        };
        _modelBuilder.Entity<User>().HasData(adminUser);



        List<Group> defaultGroups = new List<Group>() {
            new Group() {Id=1, GroupName="sedan",GroupDes="خودروی خانواده"},
            new Group() {Id=2, GroupName="coupe",GroupDes="خودروی اسپرت"},
            new Group() {Id=3, GroupName="crossover",GroupDes="خودروی جوانان"},
        };
        _modelBuilder.Entity<Group>().HasData(defaultGroups);
    }
}