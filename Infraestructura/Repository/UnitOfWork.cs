using Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IProductRepository productRepository,IEmployeeRepository employeeRepository, IRateRepository rates,
            IDetalleFacturaRepository detalleFacturaRepository,IFacturaRepository facturaRepository,IPriceRepository priceRepository)
        {
            Products = productRepository;
            Employees = employeeRepository;
            Rates = rates;
            DetalleFactura = detalleFacturaRepository;
            Factura = facturaRepository;
            Price = priceRepository;
        }
        public IProductRepository Products { get; }
        public IEmployeeRepository Employees { get; }
        public IRateRepository Rates { get; }
        public IDetalleFacturaRepository DetalleFactura { get; }
        public IFacturaRepository Factura { get; }
        public IPriceRepository Price { get; }
    }
}
