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
        public  IActionResult ListarAvatar()
        {
            try
            {
                var validaDia = aplicacao.ListarAvatar();
                return Ok(validaDia) ;
              
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
    }
}
