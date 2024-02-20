using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector.Dominio.Contratos.IRepositorio;
using Vector.Dominio.Entidades;
using Vector.Infra.Data.Contexto;
using Vector.Infra.Data.Repositorio.Comum;

namespace Vector.Infra.Data.Repositorio
{
    public class AvatarMockRepositorio : RepositorioComum<AvatarMock>, IAvatarMockRepositorio
    {
        private readonly Context _contexto;
        public AvatarMockRepositorio(Context contexto) : base(contexto)
        {
            _contexto = contexto;
        }



        public List<AvatarMock> ListarAvatar()
        {
            return contexto.AvataresMock
                .AsNoTracking()
                .OrderBy(x => x.Id)
                .ToList();
        }

        public List<AvatarMock> ListarEmailAgrupadoPorData()
        {
            var query = contexto.AvataresMock
                 .GroupBy(o => new { o.Mail, o.CreatedAt })
                 .Select(g => new AvatarMock()
                 {
                     Mail = g.Key.Mail,
                     CreatedAt = g.Key.CreatedAt
                 }).ToList();

            return new List<AvatarMock>(query);
        }

        public List<AvatarMock> ListarApenasEmail()
        {
            return null;
        }

        public List<AvatarMock> LIstarData()
        {

            return contexto.AvataresMock
                    .Select(cli => new AvatarMock
                    {
                         CreatedAt = cli.CreatedAt,
                         Mail = cli.Mail,
      
                    }).ToList();

         
            //fazendo um grande comentario


            // send a new foto


        }

        public string teste()
        {
            var teste = contexto.AvataresMock
                .GroupBy(x => x.CreatedAt.Hour.ToString())
                .Select(g => new
                {
                    CreatedAt = g.Key.ToString().ToArray(),
                    Name = g.Key.ToString().ToArray()
                })
                .ToArray().ToString();

            return teste;
        }

        public string[] outro()
        {
            return contexto.AvataresMock
                .Select(x => x.Mail)
                .ToArray();
        }
        public string[] outro2()
        {
            return contexto.AvataresMock
                .Select(x => x.Mail)
                .ToArray();
        }

        public string[] outro22()
        {
            return contexto.AvataresMock
                .Select(x => x.Mail)
                .ToArray();

      
            string some2 = string.Empty;
            string some23 = string.Empty;
            string some234 = string.Empty;

            tring some = string.Empty;
            string some2 = string.Empty;
            string some23 = string.Empty;
            string some234 = string.Empty;

            tring some = string.Empty;
            string some2 = string.Empty;
            string some23 = string.Empty;
            string some234 = string.Empty;


            string some2 = string.Empty;
            string some23 = string.Empty;
            string some234 = string.Empty;

        }

        public string[] outro222()
        {
            return contexto.AvataresMock
                .Select(x => x.Mail)
                .ToArray();
        }

        public string[] outro2222()
        {
            return contexto.AvataresMock
                .Select(x => x.Mail)
                .ToArray();
        }


        public string[] ListarEmailLimpo()
        {
            return contexto.AvataresMock
                .Select(x => x.Mail)
                .ToArray();
        }
    }
}
