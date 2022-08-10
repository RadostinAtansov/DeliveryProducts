using InkoOrders.Data;
using InkoOrders.Services;
using InkoOrders.Services.Implementation;
using InkoOrders.Services.Implementation.Storage;
using InkoOrders.Services.IStorageServices;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<InkoOrdersDBContext>();
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddTransient<IComponentService, ComponentService>();
builder.Services.AddTransient<IMaterialsInkoService, MaterialsInkoService>();
builder.Services.AddTransient<IBoughtByInkoService, BoughtByInkoSevice>();
builder.Services.AddTransient<ICreatedByInkoService, CreatedByInkoService>();
builder.Services.AddTransient<IWareInkoService, WareInkoService>();
builder.Services.AddTransient<IProviderOrder, ProviderOrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
