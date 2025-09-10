using Microsoft.EntityFrameworkCore;
using Turistando.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PasseiosDbContext>(
    options => options.UseSqlServer(
        Environment.GetEnvironmentVariable("SQL_CONNECTION")
    )
);
var app = builder.Build();

app.Run();