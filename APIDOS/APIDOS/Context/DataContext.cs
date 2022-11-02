using APIDOS.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDOS.Context
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
