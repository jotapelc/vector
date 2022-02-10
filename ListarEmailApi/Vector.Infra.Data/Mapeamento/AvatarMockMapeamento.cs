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
            builder.HasKey(pk => new { pk.id });

            builder.Property(pk => pk.id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.name)
                .HasColumnName("name")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(x => x.mail)
                .HasColumnName("mail")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(x => x.avatar)
                .HasColumnName("avatar")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(x => x.createdAt)
                .HasColumnName("createdAt")
                .HasColumnType("datetime")
                .IsRequired();

            //builder.Property(x => x.RequestIn)
            //    .HasColumnName("requestIn")
            //     .HasColumnType("datetime2")
            //     .IsRequired();
        }
    }
}
