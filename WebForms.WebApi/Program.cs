using Microsoft.EntityFrameworkCore;
using WebForms.Application.Services;
using WebForms.Core.Interfaces;
using WebForms.Persistence;
using WebForms.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(configuration.GetConnectionString(nameof(ApplicationDbContext)));
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddScoped<IUsersRepository, UsersRepository>();

builder.Services.AddScoped<UsersService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();