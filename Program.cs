using LojaFlamengoApi.Repositories;
using LojaFlamengoApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Add CORS policy
builder.Services.AddCors(options =>
{
   options.AddDefaultPolicy(builder =>
   {
      builder.AllowAnyOrigin()
             .AllowAnyHeader()
             .AllowAnyMethod();
   });
});

// Inside gen we will allow/add authorization in swwager
builder.Services.AddSwaggerGen(options =>
{
   options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
   {
      Description = "Standard Authorization Header using Bearer Scheme (\"bearer {token}\")",
      In = ParameterLocation.Header,
      Name = "Authorization",
      Type = SecuritySchemeType.ApiKey
   });

   options.OperationFilter<SecurityRequirementsOperationFilter>();
});

//This is how we can add Authentication Scheme
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
   options.TokenValidationParameters = new TokenValidationParameters
   {
      ValidateIssuerSigningKey = true,
      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
       .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
      ValidateIssuer = false,
      ValidateAudience = false,
   };
});

builder.Services.AddScoped((_) => new SqlConnectionProvider(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<StartupBase>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Add CORS middleware
app.UseCors();

//This is how you add Middleware and it should always be above Authorization
app.UseAuthentication();

app.MapControllers();

app.Run();