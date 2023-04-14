using Microsoft.EntityFrameworkCore;

namespace OglasiSource.Infrastructure.Data.Context
{
    public class DbReadContext : OglasiSourceContext
    {
        public DbReadContext(DbContextOptions<DbReadContext> options) : base(options)
        {
        }
    }
}
