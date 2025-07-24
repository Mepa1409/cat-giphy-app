using CatGiphyApi.Models;
using CatGiphyApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatGiphyApi.Controllers
    //Controlador especifico para mostrar registro de historial de busquedas realizadas
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoryController : ControllerBase
    {
        private readonly SearchHistoryService _historyService;

        public HistoryController(SearchHistoryService historyService)
        {
            _historyService = historyService;
        }

        /// <summary>
        /// Retorna el historial completo de búsquedas realizadas.
        /// </summary>
        /// <returns>Lista de objetos SearchRecord</returns>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<List<SearchRecord>>> GetHistory()
        {
            var history = await _historyService.GetAllAsync();
            return Ok(history);
        }
    }
}
