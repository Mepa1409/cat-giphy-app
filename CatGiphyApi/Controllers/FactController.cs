using CatGiphyApi.ExternalClients;
using CatGiphyApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatGiphyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FactController : ControllerBase
    {
        private readonly CatFactClient _catFactClient;

        public FactController(CatFactClient catFactClient)
        {
            _catFactClient = catFactClient;
        }

      
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CatFactResponse), 200)]
        public async Task<ActionResult<CatFactResponse>> GetFact()
        {
            var fact = await _catFactClient.GetRandomFactAsync();

            if (fact == null)
                return StatusCode(500, "No se pudo obtener un fact.");

            return Ok(fact);
        }
    }
}
