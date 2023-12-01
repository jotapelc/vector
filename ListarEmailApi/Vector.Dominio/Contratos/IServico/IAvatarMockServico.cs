using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector.Dominio.Contratos.IServico.Comum;
using Vector.Dominio.Entidades;

namespace Vector.Dominio.Contratos.IServico
{
    public interface IAvatarMockServico : IServicoComum<AvatarMock>
    {
        List<AvatarMock> ListarAvatar();
        List<AvatarMock> ListarEmailAgrupadoPorData();
        List<AvatarMock> ListarApenasEmail();
        //List<string> ListarEmailLimpo();
        List<AvatarMock> LIstarData();


        string[] ListarEmailLimpo();
    }
}
