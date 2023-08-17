using Microsoft.Extensions.DependencyInjection;
using Pacagroup.Ecommerce.Application.Validator;
using System.Runtime.CompilerServices;

namespace Pacagroup.Eccomerce.Services.WebApi.Validator
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddTransient<UsersDtoValidator> ();
            return services;
        }
    }
}
