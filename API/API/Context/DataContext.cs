using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<ProductoVendido> ProductoVendio { get; set; }
        public DbSet<Venta> Venta { get; set; }
    }

}
