using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Data.DTO;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    public class CadastroController : BaseController
    {
        private CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDTO createUsuarioDTO)
        {
            Result resultado = _cadastroService.CadastrarUsuario(createUsuarioDTO);

            if (resultado.IsFailed)
                return StatusCode(500);

            return Ok(resultado.Successes) ;
        }
    }
}
