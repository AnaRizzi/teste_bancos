using AnaDomain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnaInfra.EntityFramework
{
    public class ComentarioConfig : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder
                .ToTable("comentarios")
                .HasOne(c => c.Cliente)
                .WithMany(ct => ct.Comentarios)
                .HasForeignKey("Id_cliente");

            builder
                .Property(p => p.Mensagem)
                .HasColumnName("Comentario")
                .HasColumnType("varchar(300)")
                .IsRequired();

        }
    }
}
