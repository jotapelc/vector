using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector.Dominio.Contratos.IRepositorio;
using Vector.Dominio.Contratos.IServico;
using Vector.Dominio.Entidades;
using Vector.Dominio.Servicos.Comum;

namespace Vector.Dominio.Servicos
{
    public class AvatarMockServico : ServicoComum<AvatarMock>, IAvatarMockServico
    {
        private IAvatarMockRepositorio repositorio;

        public AvatarMockServico(IAvatarMockRepositorio repositorio) :base(repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<AvatarMock> ListarAvatar()
        {
            return repositorio.ListarAvatar();
        }

        public List<AvatarMock> ListarEmailAgrupadoPorData()
        {
            return repositorio.ListarEmailAgrupadoPorData();
        }

        //public List<AvatarMock> ListarApenasEmail()
        //{
        //    return repositorio.ListarApenasEmail();
        //}



    }
}
