using Microsoft.EntityFrameworkCore;

namespace WebAppTest.Context
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
    }
}
