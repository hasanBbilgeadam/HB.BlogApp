using HB.BlogApp.BL.Extentions;
using HB.BlogApp.DAL.Extentions;
using HB.BlogApp.Dto.EmailConfigs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddBLDepecenies();
builder.Services.AddDALDependencies(builder.Configuration.GetConnectionString("SqlCon"));


builder.Services.Configure<EmailOption>(builder.Configuration.GetSection("EmailOption"));
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
