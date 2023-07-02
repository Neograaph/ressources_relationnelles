using ApiCube.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Net;


var builder = WebApplication.CreateBuilder(args);
// builder.Listen(IPAddress.Any, 7032); // Spécifiez ici le port d'écoute de votre choix
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins",
                      builder =>
                      {
                          builder.WithOrigins("http://cube-cesi.ddns.net:4200", "http://localhost:4200")
                                 .AllowAnyHeader()
                                 .AllowAnyMethod()
                                 .SetIsOriginAllowedToAllowWildcardSubdomains()
                                 .AllowCredentials();
                      });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Configuration de l'authentification JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var secretKey = builder.Configuration.GetSection("AppSettings:Secret").Value;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:4200",
            ValidAudience = "https://localhost:4200",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("UserOnly", policy => policy.RequireRole("Citoyens"));
});


// var connectionString = builder.Configuration.GetConnectionString("containerConnection");
// builder.Services.AddDbContext<AppContexte>(x => x.Use
// Server(connectionString));
// builder.Services.AddDbContext<AppContexte>(x => x.UseMySql(connectionString));
var connectionString = builder.Configuration.GetConnectionString("containerConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 26)); // Remplacez la version par celle de votre serveur MySQL

builder.Services.AddDbContext<AppContexte>(x => x.UseMySql(connectionString, serverVersion));


var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }
app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
