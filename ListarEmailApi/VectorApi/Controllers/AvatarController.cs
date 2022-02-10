using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vector.Aplicacao.Contrato;
using VectorApi.Controllers.Base;

namespace VectorApi.Controllers
{
    public class AvatarController : BaseController
    {
        private readonly IAvatarMockAplicacao aplicacao;

        public AvatarController(IAvatarMockAplicacao aplicacao)
        {
            this.aplicacao = aplicacao;
        }

        [HttpGet]
        public  IActionResult ListarAvatar()
        {
            try
            {
                var resultado = aplicacao.ListarAvatar();
                return Ok(resultado);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops, houve um erro.: {ex.Message}");
            }
        }
    }
}
