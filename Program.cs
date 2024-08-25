using API.Helpers.Extensions;
using Estoque_App.Helpers.Contants;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<FirebaseAuthSettings>(builder.Configuration.GetSection("FirebaseAuth"));
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext(builder.Configuration.GetConnectionString("DefaultConnection") ?? "");
builder.Services.AddAutoMapper();
builder.Services.AddScopeds();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
