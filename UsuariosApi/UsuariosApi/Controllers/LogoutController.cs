using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    public class LogoutController : BaseController
    {
        private LogoutService _logoutService;

        public LogoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult DeslogaUsario()
        {
            Result resultado = _logoutService.DeslogaUsuario();
            if (resultado.IsFailed)
                return Unauthorized(resultado.Errors);

            return Ok(resultado.Successes);
        }
    }
}
