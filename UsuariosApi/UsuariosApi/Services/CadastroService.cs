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
        private RoleManager<IdentityRole<int>> _roleManager;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public  Result CadastrarUsuario(CreateUsuarioDTO createUsuarioDTO)
        {
            Usuario usuario = _mapper.Map<Usuario>(createUsuarioDTO);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);

            Task<IdentityResult> resultadoIdentity =  _userManager
                .CreateAsync(usuarioIdentity, createUsuarioDTO.Password);

            // var createRoleResult = _roleManager
            //   .CreateAsync(new IdentityRole<int>("admin")).Result;

            //var usuarioRoleResult = _userManager
            //   .AddToRoleAsync(usuarioIdentity, "admin").Result;

            if (resultadoIdentity.Result.Succeeded)
                return Result.Ok();
            return Result.Fail("Falha ao cadastrar");
        }
    }
}
