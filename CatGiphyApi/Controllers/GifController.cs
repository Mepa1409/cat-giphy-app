using CatGiphyApi.ExternalClients;
using CatGiphyApi.Models;
using CatGiphyApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatGiphyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GifController : ControllerBase
    {
        private readonly GiphyClient _giphyClient;
        private readonly CatFactClient _catFactClient;
        private readonly SearchHistoryService _historyService;

        public GifController(
            GiphyClient giphyClient,
            CatFactClient catFactClient,
            SearchHistoryService historyService)
        {
            _giphyClient = giphyClient;
            _catFactClient = catFactClient;
            _historyService = historyService;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<object>> GetGif([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("El parámetro 'query' es obligatorio.");

            var gifUrl = await _giphyClient.GetGifUrlAsync(query);

            if (gifUrl == null)
                return NotFound("No se encontró ningún GIF para la consulta dada.");

            // Llamar al catfact para asociar uno con esta búsqueda
            var catFact = await _catFactClient.GetRandomFactAsync();

            var record = new SearchRecord
            {
                Date = DateTime.UtcNow,
                Fact = catFact.Fact,
                QueryWords = query,
                GifUrl = gifUrl
            };

            await _historyService.SaveSearchAsync(record);

            return Ok(new { fact = catFact.Fact, gif = gifUrl });
        }
    }
}
