using AnaDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace AnaInfra.EntityFramework
{
    public class ClienteContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Comentario> Comentario { get; set; }

        private string _connection;

        public ClienteContext(string ConnectionString)
        {
            _connection = ConnectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new ComentarioConfig());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connection);
        }
    }
}
