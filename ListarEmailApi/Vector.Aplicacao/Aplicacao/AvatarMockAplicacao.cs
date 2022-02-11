using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector.Aplicacao.Contrato;
using Vector.Aplicacao.DTO;
using Vector.Dominio.Contratos.IServico;
using Vector.Dominio.Entidades;
using Vector.Servicos.EmailApi.Contrato;

namespace Vector.Aplicacao.Aplicacao
{
    public class AvatarMockAplicacao : IAvatarMockAplicacao
    {
        private readonly IAvatarMockServico servico;
        private readonly IRequestApi request;
        private readonly IMapper mapper;

        public AvatarMockAplicacao(IAvatarMockServico servico, IRequestApi request, IMapper mapper)
        {
            this.servico = servico;
            this.request = request;
            this.mapper = mapper;
        }

        public List<AvatarMockDTO> ListarAvatar()
        {
            var listaBD = servico.ListarAvatar();
            try
            {
                if (listaBD.Count <= 0)
                {
                    listaBD = ListarApi();
                    servico.BulkInsert(listaBD);
                }
                else if (listaBD[0].SavedIn < DateTime.Today)
                {
                    listaBD = ListarApi();
                    servico.BulkUpdate(listaBD);
                }

                var resultado = mapper.Map<List<AvatarMockDTO>>(listaBD);
                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<AvatarMock> ListarApi()
        {
            var novaLista = new List<AvatarMock>();
            try
            {
                var lista = request.ListarApi();

                if (lista == null)
                    return null;

                novaLista = lista;
            }
            catch (Exception)
            {
                return null;
            }
            return novaLista;
        }

        public List<AvatarMockDTOGroupBy> ListarEmailAgrupadoPorData()
        {
            var lista = servico.ListarEmailAgrupadoPorData();
            if (lista == null)
                return null;

            var resultado = mapper.Map<List<AvatarMockDTOGroupBy>>(lista);
            return resultado;

        }

        //public List<AvatarMock> ListarApenasEmail()
        //{
        //    var listarMail = servico.ListarApenasEmail();
        //    if (listarMail == null)
        //        ListarAvatar();

        //    return listarMail; 
        //}
    }
}
