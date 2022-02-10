using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector.Dominio.Entidades;

namespace Vector.Servicos.EmailApi.Contrato
{
    public interface IRequestApi
    {
        List<AvatarMock> ListarAvatar();
        List<AvatarMock> ListarEmailAgrupadoPorData();
    }
}
