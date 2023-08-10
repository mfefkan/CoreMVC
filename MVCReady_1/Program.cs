using Microsoft.EntityFrameworkCore;
using MVCReady_1.Models.Context;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContextPool<MyContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")).UseLazyLoadingProxies());


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization(); //Identity 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Category}/{action=ListCategories}/{id?}");

app.Run();
