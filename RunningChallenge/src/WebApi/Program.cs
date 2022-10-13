using Application;
using Application.Abstract;
using Application.CustomSettings;
using Domain.Models;
using Infrastructure;
using Infrastructure.Identity;
using Infrastructure.Identity.Seed;
using Infrastructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Services;
using WebAPI;
using WebAPI.Configuration;
using WebAPI.ControllersHelpers;
using WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IUriService>(o =>
{
    var accessor = o.GetRequiredService<IHttpContextAccessor>();
    var request = accessor.HttpContext.Request;
    var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
    return new UriService(uri);
});

builder.Services.AddMediatR(typeof(ApplicationAssemblyMarker));
builder.Services.AddAutoMapper(typeof(PresentationAssemblyMarker));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IMarathonRepository, MarathonRepository>();
builder.Services.AddScoped<IInvitationRepository, InvitationRepository>();
builder.Services.AddScoped<IMedalRepository, MedalRepository>();
builder.Services.AddScoped<LoggerHelper>();
builder.Services.AddIdentityServices(builder.Configuration);

// Set up lowercase route urls
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Set up Custom Settings
builder.Services.Configure<CustomSettings>(
    builder.Configuration.GetSection(
        nameof(CustomSettings)
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseRequestTimeLogger();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var userManager = services.GetRequiredService<UserManager<User>>();
await UserCreator.SeedAsync(userManager);

app.Run();