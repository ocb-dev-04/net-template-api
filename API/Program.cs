using API;
using API.Config;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfiguration Configuration = builder.Configuration;

builder.Services.AddDatabaseServices(Configuration);
builder.Services.AddAutomapperServices();

builder.Services.AddRepositoriesScopes();
builder.Services.AddTrasients();

builder.Services.AddJWTServices(Configuration);
builder.Services.AddMediatR(AppDomain.CurrentDomain.Load(nameof(Core)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
