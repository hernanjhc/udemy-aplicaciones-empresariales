using AutoMapper;
using Pacagroup.Eccomerce.Application.DTO;
using Pacagroup.Eccomerce.Application.Interface;
using Pacagroup.Eccomerce.Application.Main;
using Pacagroup.Eccomerce.Domain.Core;
using Pacagroup.Eccomerce.Domain.Entity;
using Pacagroup.Eccomerce.Infraestructure.Interface;
using Pacagroup.Eccomerce.Infraestructura.Data;
using Pacagroup.Eccomerce.Infraestructura.Repository;
using Pacagroup.Eccomerce.Transversal.Common;
using Pacagroup.Eccomerce.Transversal.Mapper;
using Microsoft.Extensions.Configuration;
using Pacagroup.Eccomerce.Domain.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));


//se crea una vez y se reutiliza
builder.Services.AddScoped<IConnectionFactory, ConnectionFactory>();

//se instancia una vez por solicitud
builder.Services.AddScoped<ICustomersApplication, CustomersApplication>();
builder.Services.AddScoped<ICustomersDomain, CustomersDomain>();
builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();


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
