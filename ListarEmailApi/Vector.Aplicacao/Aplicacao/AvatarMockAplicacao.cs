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

            var lista = new List<AvatarMockDTO>();
            try
            {
                var listas = request.ListarAvatar();
               
                if (lista == null)
                {
                    return null;
                }
                lista = mapper.Map<List<AvatarMockDTO>>(listas);
            }
            catch (Exception)
            {

                return null;
            }
                


            return lista;
        }
    }
}
