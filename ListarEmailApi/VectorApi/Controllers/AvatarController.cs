using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Vector.Aplicacao.Contrato;
using Vector.Aplicacao.DTO;
using Vector.Dominio.Entidades;
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

        [HttpGet("ListByMail")]
        [Authorize(Roles = "admin")]
        public IActionResult ListarAvatar()
        {
            try
            {
                var validaDia = aplicacao.ListarAvatar();
                return Ok(validaDia);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops, houve um erro.: {ex.Message}");
            }
        }

        [HttpGet("ListarApenasEmail")]
        [Authorize(Roles = "admin")]
        public IActionResult ListarApenasEmail()
        {
            try
            {
                var validaDia = aplicacao.ListarApenasEmail();
                return Ok(validaDia);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops, houve um erro.: {ex.Message}");
            }
        }

        [HttpGet("GroupByDate")]
        public IActionResult ListaAgrupadaPorData()
        {
            try
            {
                var outro = aplicacao.ListarEmailAgrupadoPorData();
                return Ok(outro);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops, houve um erro.: {ex.Message}");
            }
        }

        [HttpGet("emailLimpo")]
        [Authorize(Roles = "admin")]
        public IActionResult EmailLmpo()
        {
            try
            {
                var outro = aplicacao.ListarEmailLimpo();
                return Ok(outro);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops, houve um erro.: {ex.Message}");
            }
        }

        [HttpGet("data")]
        [Authorize(Roles = "admin")]
        public IActionResult data()
        {
            try
            {
                var outro = aplicacao.LIstarData();
                return Ok(outro);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops, houve um erro.: {ex.Message}");
            }
        }
    }
}
