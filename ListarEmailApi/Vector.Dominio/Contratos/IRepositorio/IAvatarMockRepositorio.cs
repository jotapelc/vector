using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector.Dominio.Contratos.IRepositorio.Comum;
using Vector.Dominio.Entidades;

namespace Vector.Dominio.Contratos.IRepositorio
{
    public interface IAvatarMockRepositorio : IRepositorioComum<AvatarMock>
    {
        List<AvatarMock> ListarAvatar();
        List<AvatarMock> ListarEmailAgrupadoPorData();
    }
}
