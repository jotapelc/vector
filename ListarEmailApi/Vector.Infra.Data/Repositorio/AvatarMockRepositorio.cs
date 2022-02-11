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

        //public List<AvatarMock> ListarApenasEmail()
        //{
        //List<AvatarMock> listaEmail = (from a in contexto.AvataresMock
        //                               select new AvatarMock { 
        //                                   Mail = a.Mail,
        //                                   CreatedAt = a.CreatedAt
        //                               }).ToString()
        //                               .GroupBy(x => x.CreatedAt).Select(x => new {

        //                               })
        //                               .ToList();
        //return listaEmail;
        //}
    }
}
