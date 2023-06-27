using CarShop.Core.Interface;
using CarShop.Core.Service;
using CarShop.Database.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
//builder.Services.AddMvc(option => option.EnableEndpointRouting = false);

builder.Services.AddScoped<DatabaseContext, DatabaseContext>();
builder.Services.AddScoped<IGroup, GroupService>();
builder.Services.AddScoped<IProduct, ProductService>();
builder.Services.AddScoped<IAccount, AccountService>();

var app = builder.Build();

//if (builder.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}

////see error info on on host (remove after stabled)
//app.UseDeveloperExceptionPage();


app.UseRouting();
app.UseStaticFiles();


//app.MapGet("/", () => "Hello World!");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
            name: "area",
            pattern: "{area:exists}/{controller=Panel}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=home}/{action=index}/{id?}");

});

app.Run();
