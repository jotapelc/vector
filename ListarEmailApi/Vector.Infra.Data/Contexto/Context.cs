using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector.Dominio.Entidades;
using Vector.Infra.Data.Mapeamento;

namespace Vector.Infra.Data.Contexto
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<AvatarMock> AvataresMock { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AvatarMockMapeamento());

            base.OnModelCreating(modelBuilder);
        }
    }
}
