using System.Text;
using Application.Abstract;
using Domain.Models;
using Infrastructure.Identity.Models;
using Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Identity;

public static class IdentityServiceExtensions
{
    public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services.AddIdentity<User, IdentityRole<int>>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<IAuthenticationService, AuthenticationService>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
              .AddJwtBearer(o =>
              {
                  o.RequireHttpsMetadata = false;
                  o.SaveToken = false;
                  o.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ClockSkew = TimeSpan.Zero,
                      ValidIssuer = configuration["JwtSettings:Issuer"],
                      ValidAudience = configuration["JwtSettings:Audience"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                  };

                  o.Events = new JwtBearerEvents()
                  {
                      /*OnAuthenticationFailed = c =>
                      {
                          c.NoResult();
                          c.Response.StatusCode = 500;
                          c.Response.ContentType = "text/plain";
                          return c.Response.WriteAsync(c.Exception.ToString());
                      },*/
                      //OnChallenge = context =>
                      //{
                      //    context.HandleResponse();
                      //    context.Response.StatusCode = 401;
                      //    context.Response.ContentType = "application/json";
                      //    var result = JsonConverter.("401 Not authorized");
                      //    return context.Response.WriteAsync(result);
                      //},
                      //OnForbidden = context =>
                      //{
                      //    context.Response.StatusCode = 403;
                      //    context.Response.ContentType = "application/json";
                      //    var result = JsonConvert.SerializeObject("403 Not authorized");
                      //    return context.Response.WriteAsync(result);
                      //},
                  };
              });

    }
}