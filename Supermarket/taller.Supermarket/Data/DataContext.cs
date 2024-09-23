using Microsoft.EntityFrameworkCore;
using taller.Supermarket.Data.Entities;

namespace taller.Supermarket.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Administrador> Administrador { get; set; }

    }
}
