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

        public AvatarMock CriarNoBd(List<AvatarMock> avatarMock)
        {

            try
            {
                servico.BulkInsert(avatarMock);

            }
            catch (Exception ex)
            {

                return null;
            }
            return null;

        }

        public AvatarMock BulkUpdate(List<AvatarMock> avatarMock)
        {
            try
            {
                servico.BulkUpdate(avatarMock);
            }
            catch (Exception ex)
            {

                return null;
            }
            return null;

        }

        public List<AvatarMock> ListarAvatar()
        {
            var listaDb = new List<AvatarMock>();
          
            try
            {
                listaDb = servico.ListarAvatar();
                if (listaDb[0].Id < 0)
                {
                    ListarApi();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return listaDb;


        }

        public List<AvatarMock> ListarAvatarNoBanco()
        {
            var listaDb = new List<AvatarMock>();
            try
            {
                listaDb = servico.SelecionarLista();
                if (listaDb == null)
                    return null;
            }
            catch (Exception ex)
            {

                throw;
            }
            return listaDb;
        }

        public List<AvatarMock> ListarApi()
        {
            var lista = new List<AvatarMock>();
            try
            {
                var listas = request.ListarApi();

                if (lista == null)
                {
                    return null;
                }
                lista = mapper.Map<List<AvatarMock>>(listas);
            }
            catch (Exception)
            {

                return null;
            }

            return lista;
        }
    }
}
