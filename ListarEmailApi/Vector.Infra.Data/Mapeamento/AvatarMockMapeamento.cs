using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector.Dominio.Entidades;

namespace Vector.Infra.Data.Mapeamento
{
    public class AvatarMockMapeamento : IEntityTypeConfiguration<AvatarMock>
    {

        public void Configure(EntityTypeBuilder<AvatarMock> builder)
        {

            builder.ToTable("avatares_mock");
            builder.HasKey(pk => new { pk.Id });

            builder.Property(pk => pk.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(x => x.Mail)
                .HasColumnName("mail")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(x => x.Avatar)
                .HasColumnName("avatar")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnName("createdAt")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(x => x.RequestIn)
                .HasColumnName("requestIn")
                 .HasColumnType("datetime2")
                 .IsRequired();
        }
    }
}
