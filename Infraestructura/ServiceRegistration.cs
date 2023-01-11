using Application.Interface;
using Infraestructura.Repository;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IRateRepository, RateRepository>();
            services.AddTransient<IFacturaRepository, FacturaRepository>();
            services.AddTransient<IPriceRepository, PriceRepository>();
            services.AddTransient<IDetalleFacturaRepository, DetalleFacturaRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}