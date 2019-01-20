using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Transforma.API.Controllers;
using Transforma.Domain.Commands;
using Transforma.infrastructure;

namespace TransformaPalavrasProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransformaPalavraController : BaseController
    {
        public TransformaPalavraController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Transformar a primeira palavra pela segunda palavra
        /// </summary>
        /// <param name="command">Comando</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> TransformarPalavra([FromBody]TransformarPalavraCommand command)
        {
            var response = await _mediator.Send(command);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }
    }
}
