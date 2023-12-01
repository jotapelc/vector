using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector.Dominio.Contratos.IServico.Comum
{
    public interface IServicoComum<TEntidade>
    {
        void Adicionar(TEntidade entidade);
        void Alterar(TEntidade entidade);
        void Remover(TEntidade entidade);
        void BulkInsert(List<TEntidade> entidade);
        void BulkUpdate(List<TEntidade> entidade);
        List<TEntidade> SelecionarLista();
    }
}
