using Microsoft.EntityFrameworkCore;

namespace Horticlima.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<CarrinhoItem> CarrinhoItens { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
