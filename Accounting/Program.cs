using Accounting.Interfaces;
using Accounting.Models;
using Accounting.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AccountingContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Accounting")),ServiceLifetime.Transient);


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IRepository<>), typeof(AccountingRepository<>));

builder.Services.AddScoped<IDebitCodeService, DebitCodeService>();
builder.Services.AddScoped<ISerachService, SerachService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IRecordAccountingService, RecordAccountingService>();
builder.Services.AddScoped<ICalculateService, CalculateService>();

// Add service Swageer
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwaggerUI(); // UI Swagger

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSwagger(x => x.SerializeAsV2 = true); //Run swagger
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
