using Microsoft.Extensions.DependencyInjection;
using Sales.Data.Core;
using Sales.Application.Services;
using Sales.Data.Interfaces;
using Sales.Data.Repositories;
using Sales.Domain.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.ServiceProvider
{
    public class ServiceProviderManager
    {
        protected readonly IServiceCollection _services;
        public ServiceProviderManager(IServiceCollection services)
        {
            _services = services;
        }

        public void Run()
        {
            _services.AddScoped<ICustomerRepository, CustomerRepository>();
            _services.AddScoped<ICustomerService, CustomerService>();
            _services.AddScoped<IProductRepository, ProductRepository>();
            _services.AddScoped<IProductService, ProductService>();
            _services.AddScoped<ISaleRepository, SaleRepository>();
            _services.AddScoped<ISaleService, SaleService>();
            _services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
