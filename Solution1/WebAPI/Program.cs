using Application;
using Application.Abstract;
using Application.CustomSettings;
using Infrastructure;
using Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WebAPI;
using WebAPI.ControllersHelpers;
using WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddMediatR(typeof(ApplicationAssemblyMarker));
builder.Services.AddAutoMapper(typeof(PresentationAssemblyMarker));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IMarathonRepository, MarathonRepository>();
builder.Services.AddScoped<ControllerHelper>();

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

app.UseAuthorization();

app.UseRequestTimeLogger();

app.MapControllers();

app.Run();
