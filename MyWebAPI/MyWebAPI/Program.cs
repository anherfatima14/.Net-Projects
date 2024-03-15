using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MyWebAPI.Models;
using MyWebAPI.Provider;
using MyWebAPI.Repository;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Configuration = configuration;

// Add services to the container
builder.Services.AddSingleton<IUserRepository, UserRepository>(sp =>
    new UserRepository(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<IUserProvider, UserProvider>();



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(options =>
       {
           options.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuer = true,
               ValidateAudience = true,
               ValidateLifetime = true,
               ValidateIssuerSigningKey = true,
               ValidIssuer = "Jwt:Issuer",
               ValidAudience = "Jwt:Issuer",
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Jwt:Key"))
           };
       });


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
