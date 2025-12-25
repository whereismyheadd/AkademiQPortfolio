using Microsoft.EntityFrameworkCore;
using portfolyoDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<portfolyodbContext>(options => options.UseSqlServer(
   builder.Configuration.GetConnectionString("DefaultConnection")));

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

//Program cs -->projemizin ilk açýldýðýnda çalýþacak kodlar

//Projem ilk açýldýðýnda veri tabanýna baðlanmasýný istiyorsun

//Bunun için veri tabanýný temsil eden sýnýf(DBCONTEXT) bunu burada tanýmlaman gerekiyor