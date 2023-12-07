using Microsoft.EntityFrameworkCore;
using Entities.Entities;
using Infrastructure.Configuration;
using Domain.Interfaces.Generics;
using Infrastructure.Repository.Generics;
using Domain.Interfaces.ICategories;
using Infrastructure.Repository;
using Domain.Interfaces.IExpense;
using Domain.Interfaces.IFinancialSystem;
using Domain.Interfaces.IFinancialSystemUser;
using Domain.Interfaces.IServices;
using Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebApi.Token;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextBase>(options =>
               options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
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

// JWT Token
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(option =>
             {
                 option.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = false,
                     ValidateAudience = false,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,

                     ValidIssuer = "Test.Securiry.Bearer",
                     ValidAudience = "Test.Securiry.Bearer",
                     IssuerSigningKey = JwtSecurityKey.Create("Secret_Key_12345678")
                 };

                 option.Events = new JwtBearerEvents
                 {
                     OnAuthenticationFailed = context =>
                     {
                         Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                         return Task.CompletedTask;
                     },
                     OnTokenValidated = context =>
                     {
                         Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                         return Task.CompletedTask;
                     }
                 };
             });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Cors configuration "acesso do front ao back"
var devClient = "https://localhost:44365";

app.UseCors(x =>
x.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
.WithMethods(devClient));

app.UseHttpsRedirection();

// new... jwt
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
