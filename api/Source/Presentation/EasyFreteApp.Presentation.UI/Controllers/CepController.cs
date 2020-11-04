using EasyFreteApp.Domain;
using EasyFreteApp.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EasyFreteApp.Presentation.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly ICepService _service;

        public CepController(ICepService service)
        {
            _service = service;
        }

        [HttpGet("{cep}")]
        [ProducesResponseType(typeof(CepDomain), 200)]
        public async Task<ActionResult<CepDomain>> Get(string cep)
        {
            try
            {
                var retorno = await _service.GetAsync(cep);

                if (retorno == null)
                    return NotFound();

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
