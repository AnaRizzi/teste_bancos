using AnaDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace AnaInfra.EntityFramework
{
    public class ClienteContext : DbContext
    {
        private string _connection;

        public ClienteContext(string ConnectionString)
        {
            _connection = ConnectionString;
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfig());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connection);
        }
    }
}
