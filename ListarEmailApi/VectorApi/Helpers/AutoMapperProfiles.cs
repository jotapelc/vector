using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vector.Aplicacao.DTO;
using Vector.Dominio.Entidades;

namespace VectorApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AvatarMock, AvatarMockDTO>().ReverseMap();
            CreateMap<AvatarMock, AvatarMockDTOGroupBy>().ReverseMap();
        }
    }
}
