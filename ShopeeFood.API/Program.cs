global using ShopeeFood.DAL.EF.Context;
using Microsoft.EntityFrameworkCore;
using ShopeeFood.Commons.Constants;
using ShopeeFood.DAL.EF.Entities;
using ShopeeFood.DAL.Repositories.Contracts;
using ShopeeFood.DAL.Repositories.Implementations;
using ShopeeFood.Services.Contracts;
using ShopeeFood.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<ShopeeFoodDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(SystemConstants.MainConnectionString));
});

builder.Services.AddIdentity<Customer, AppRole>()
    .AddEntityFrameworkStores<ShopeeFoodDbContext>();

builder.Services.AddTransient<IPartnerService, PartnerService>(); 
builder.Services.AddTransient<IPartnerRepository, PartnerRepository>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
