using AutoMapper;
using CRUDHw.Mapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var mapConfig = new MapperConfiguration(c =>
{
    c.AddProfile<AutoMapperProfile>();
});

var mapper = mapConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
