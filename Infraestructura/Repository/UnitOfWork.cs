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
        public UnitOfWork(IProductRepository productRepository,IEmployeeRepository employeeRepository)
        {
            Products = productRepository;
            Employees = employeeRepository;
        }
        public IProductRepository Products { get; }
        public IEmployeeRepository Employees { get; }
    }
}
