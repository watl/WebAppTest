using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        IEmployeeRepository Employees { get; }
        IDetalleFacturaRepository DetalleFactura { get; }
        IFacturaRepository Factura { get; }
        IRateRepository Rates { get; }
        IPriceRepository Price { get; }
    }
}
