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
using System.ComponentModel;
using Swashbuckle.Swagger;
using System.Reflection;
using License = Swashbuckle.Swagger.License;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

// Add services to the container.
string myPolicy = "policyApiEcommerce";
builder.Services.AddCors(options => options.AddPolicy(myPolicy,
    build => build.WithOrigins(configuration["Config:OriginCors"])
                .AllowAnyHeader()
                .AllowAnyMethod()));

builder.Services.AddCors();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//c =>
//{
//    c.SwaggerDoc("v1", new Info
//    {
//        version = "v1",
//        title = "Pacagroup Technology Services API Network",
//        termsOfService = "None"
//        ,
//        contact = new Swashbuckle.Swagger.Contact
//        {
//            name = "Joaco Castillo",
//            email = "hernan.jhc@gmail.com",
//            url = ""
//        }
//        ,
//        license = new Swashbuckle.Swagger.License
//        {
//            name = "Use under LICK"
//            //,
//            //url = ""
//        }
//    });
//    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
//    c.IncludeXmlComments(xmlPath);
//});

builder.Services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));


//se crea una vez y se reutiliza
builder.Services.AddScoped<IConnectionFactory, ConnectionFactory>();

//se instancia una vez por solicitud
builder.Services.AddScoped<ICustomersApplication, CustomersApplication>();
builder.Services.AddScoped<ICustomersDomain, CustomersDomain>();
builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();

builder.Services.AddMvc();

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
app.UseCors(myPolicy);

app.Run();
