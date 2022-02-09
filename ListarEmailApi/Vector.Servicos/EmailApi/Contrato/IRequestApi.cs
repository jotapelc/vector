using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector.Aplicacao.DTO;

namespace Vector.Servicos.EmailApi.Contrato
{
    public interface IRequestApi
    {
        Task<List<AvatarMockDTO>> ListarAvatar();
        List<AvatarMockDTO> ListarEmailAgrupadoPorData();
    }
}
