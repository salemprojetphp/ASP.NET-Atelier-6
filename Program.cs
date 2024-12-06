using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using _.Data;
using _.Models;
using _.Repositories;
using _.Services;
using _.ServiceContracts;
using _.DTOs;
using _.Mappings;
using AutoMapper;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        options.SignIn.RequireConfirmedAccount = true; // Requiert une confirmation par e-mail lors de l'enregistrement
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders(); // Nécessaire pour le support de l'authentification à deux facteurs


builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddControllers();
builder.Services.AddScoped(typeof(IRepository<Category>), typeof(Repository<Category>));
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseHttpsRedirection();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }

// Test de mappage AutoMapper
// var configuration = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
// var mapper = configuration.CreateMapper();

// var category = new Category { Id = 1, Nom = "Test", Description = "Description" };
// var categoryDto = mapper.Map<CategoryDTO>(category);

// Console.WriteLine($"DTO: Id={categoryDto.Id}, Name={categoryDto.Nom}, Description={categoryDto.Description}");

app.Run();
