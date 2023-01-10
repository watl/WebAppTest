using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IRateRepository:IGenericRepository<Rate>
    {
        Task<Rate> GetByDateRateAsync(DateTime fch);
        Task<IReadOnlyList<Rate>> GetByMonthRateAsync(DateTime initfch, DateTime finalfch);
    }
}
