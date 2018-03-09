using Microsoft.EntityFrameworkCore;
using TesteEmprego.Models;

namespace TesteEmprego.Data
{
    public class BDContext : DbContext
    {
        public BDContext(DbContextOptions<BDContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
    }
}
