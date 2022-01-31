using AnaDomain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnaInfra.EntityFramework
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder
                .ToTable("Clientes")
                .HasKey("Id");

            builder
                .Property(p => p.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder
                .Property(p => p.Cpf)
                .HasColumnType("varchar(11)")
                .IsRequired();                
        }
    }
}
