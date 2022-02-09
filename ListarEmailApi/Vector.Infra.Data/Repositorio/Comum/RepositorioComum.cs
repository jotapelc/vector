using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector.Dominio.Contratos.IRepositorio.Comum;
using Vector.Infra.Data.Contexto;

namespace Vector.Infra.Data.Repositorio.Comum
{
    public class RepositorioComum<TEntidade> : IRepositorioComum<TEntidade> where TEntidade : class
    {
        protected readonly Context contexto;
        protected readonly DbSet<TEntidade> dbSet;

        public RepositorioComum(Context contexto)
        {
            this.contexto = contexto;
            dbSet = contexto.Set<TEntidade>();
        }

        public void Adicionar(TEntidade entidade)
        {
            dbSet.Add(entidade);
            contexto.SaveChanges();
        }

        public void Alterar(TEntidade entidade)
        {
            dbSet.Update(entidade);
            contexto.SaveChanges();
        }

        public void Remover(TEntidade entidade)
        {
            dbSet.Remove(entidade);
            contexto.SaveChanges();
        }

        public List<TEntidade> SelecionarLista()
        {
            return dbSet.ToList();
        }
    }
}
