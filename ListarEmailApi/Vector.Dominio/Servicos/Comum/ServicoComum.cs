using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector.Dominio.Contratos.IRepositorio.Comum;
using Vector.Dominio.Contratos.IServico.Comum;

namespace Vector.Dominio.Servicos.Comum
{
    public class ServicoComum<TEntidade> : IServicoComum<TEntidade> where TEntidade : class
    {
        private IRepositorioComum<TEntidade> repositorioComum;

        public ServicoComum(IRepositorioComum<TEntidade> repositorioComum)
        {
            this.repositorioComum = repositorioComum;
        }

        public void Adicionar(TEntidade entidade)
        {
            repositorioComum.Adicionar(entidade);
        }

        public void BulkInsert(List<TEntidade> entidade)
        {
            repositorioComum.BulkInsert(entidade);
        }

        public void Alterar(TEntidade entidade)
        {
            repositorioComum.Alterar(entidade);
        }

        public void Remover(TEntidade entidade)
        {
            repositorioComum.Remover(entidade);
        }

        public void BulkUpdate(List<TEntidade> entidade)
        {
            repositorioComum.BulkUpdate(entidade);
        }

        public List<TEntidade> SelecionarLista()
        {
            return repositorioComum.SelecionarLista();
        }

    }
}
