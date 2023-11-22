using Microsoft.EntityFrameworkCore;
using Entities.Entities;
using Infrastructure.Configuration;
using Domain.Interfaces.Generics;
using Infrastructure.Repository.Generics;
using Domain.Interfaces.ICategories;
using Infrastructure.Repository;
using Domain.Interfaces.IExpenses;
using Domain.Interfaces.IFinancialSystem;
using Domain.Interfaces.IFinancialSystemUser;
using Domain.Interfaces.IServices;
using Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextBase>(options =>
               options.UseSqlServer(
                   // builder.Configuration.GetConnectionString("DefaultConnection")));
                   builder.Configuration.GetConnectionString("")));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContextBase>();

// INTERFACE AND REPOSITORY
builder.Services.AddSingleton(typeof(InterfaceGeneric<>), typeof(GenericsRepository<>));

builder.Services.AddSingleton<InterfaceCategory, CategoryRepository>();
builder.Services.AddSingleton<InterfaceExpense, ExpenseRepository>();
builder.Services.AddSingleton<InterfaceFinancialSystem, FinancialSystemRepository>();
builder.Services.AddSingleton<InterfaceFinancialSystemUser, FinancialSystemUserRepository>();

// DOMAIN SERVICE
builder.Services.AddSingleton<IServiceCategory, ServiceCategory>();
builder.Services.AddSingleton<IServiceExpense, ServiceExpense>();
builder.Services.AddSingleton<IServiceFinancialSystem, ServiceFinancialSystem>();
builder.Services.AddSingleton<IServiceFinancialSystemUser, ServiceFinancialSystemUser>();

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
