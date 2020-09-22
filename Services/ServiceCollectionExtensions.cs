using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPProject.Data.Repository;
using VPProject.Models.Entities;
using VPProject.Services.Interface;
using VPProject.Services.Service;

namespace VPProject.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCommonInfrastructure(this IServiceCollection serviceCollection)
        {
            //Context
            serviceCollection.AddScoped<IDataContext, VPContext>();
            
            //Repositories
            serviceCollection.AddScoped<IRepository<Country>, Repository<Country>>();

            //Services
            serviceCollection.AddScoped<ICountryService, CountryService>();
            serviceCollection.AddScoped<IValidationService, ValidationService>();
            serviceCollection.AddScoped<IPenaltyService, PenaltyService>();            
        }
    }
}
