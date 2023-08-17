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
using Pacagroup.Eccomerce.Services.WebApi.Helpers;
using Pacagroup.Eccomerce.Infraestructure.Repository;
using Pacagroup.Ecommerce_.Transversal.Logging;
using Microsoft.OpenApi.Models;
using Pacagroup.Eccomerce.Services.WebApi.Validator;

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
builder.Services.AddSwaggerGen(c =>
{
c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
{
    Version = "v1",
    Title = "Pacagroup Technology Services API Network",
    TermsOfService = new Uri("https://pacagroup.com/terms"),
    Contact = new Microsoft.OpenApi.Models.OpenApiContact
    {
        Name = "Joaco Castillo",
        Email = "hernan.jhc@gmail.com",
        Url = new Uri("https://pacagroup.com/contact")
    }
    ,
    License = new Microsoft.OpenApi.Models.OpenApiLicense
    {
        Name = "Use under LICK",
        Url = new Uri("https://pacagroup.com/license")
    }
});
var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
c.IncludeXmlComments(xmlPath);

c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
{
    Description = "Authorization by Api key.",
    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
    Name = "Authorization"
});

c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
            new string[]{}
    }
});
});

builder.Services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));


//se crea una vez y se reutiliza
builder.Services.AddScoped<IConnectionFactory, ConnectionFactory>();

//se instancia una vez por solicitud
builder.Services.AddScoped<ICustomersApplication, CustomersApplication>();
builder.Services.AddScoped<ICustomersDomain, CustomersDomain>();
builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();
builder.Services.AddScoped<IUsersApplication, UsersApplication>();
builder.Services.AddScoped<IUsersDomain, UsersDomain>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

builder.Services.AddMvc();

builder.Services.AddValidator();

var appSettingsSection = configuration.GetSection("Config");
builder.Services.Configure<AppSettings>(appSettingsSection);

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
app.UseAuthentication();

app.Run();
