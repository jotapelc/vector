using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Data.DTO;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public  Result Cadastrarusuario(CreateUsuarioDTO createUsuarioDTO)
        {
            Usuario usuario = _mapper.Map<Usuario>(createUsuarioDTO);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);

            var resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, createUsuarioDTO.Password);

            if (resultadoIdentity.Result.Succeeded)
                return Result.Ok();

            return Result.Fail("Falha ao cadastrar");
        }
    }
}
