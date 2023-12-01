﻿using Microsoft.EntityFrameworkCore;
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

            //var saida = (from avatars in contexto.AvataresMock
            //             select new 
            //             {
            //                 avatars.CreatedAt,
            //                 avatars.Mail
            //             }).ToArray();

            //return saida;

            return contexto.AvataresMock
                    .Select(cli => new AvatarMock
                    {
                         CreatedAt = cli.CreatedAt,
                         Mail = cli.Mail,
      
                    }).ToList();

            //return contexto.AvataresMock
            //    .AsNoTracking()
            //    .ToList();
            //int[] oi = null;
            //string[] vs = null;
            //var datas = contexto.AvataresMock
            //    .GroupBy(o => new { o.Mail, o.CreatedAt })
            //    .Select(g => new AvatarMock()
            //    {
            //        Mail = g.Key.Mail,
            //        CreatedAt = g.Key.CreatedAt
            //    }).ToArray();

            //var query = from avatars in datas
            //           group new { avatars.CreatedAt.Hour, avatars.Mail }
            //           by avatars.CreatedAt.Hour into newGroup
            //           select newGroup;

            //foreach (var newGroup in query)
            //{
            //    Console.WriteLine($"Hora: {newGroup.Key}");
            //    oi.Append(newGroup.Key);
            //    foreach (var item in newGroup)
            //    {
            //        Console.WriteLine($"\t Email: { item.Mail}");
            //        vs.Append( item.Mail );
            //    }
            //}

            //Console.WriteLine(oi);
            //Console.WriteLine(vs);







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

        public string[] ListarEmailLimpo()
        {
            return contexto.AvataresMock
                .Select(x => x.Mail)
                .ToArray();
        }
    }
}
