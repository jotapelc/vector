using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector.Aplicacao.DTO;
using Vector.Dominio.Entidades;

namespace Vector.Aplicacao.Contrato
{
    public interface IAvatarMockAplicacao
    {
        List<AvatarMockDTO> ListarAvatar();
    }
}
