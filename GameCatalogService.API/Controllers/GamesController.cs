using GameCatalogService.API.Filters;
using GameCatalogService.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameCatalogService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;

        public GamesController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        [ApiKey] // API key validation for this action
        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            var games = await _gameRepository.GetGamesAsync();
            return Ok(games);
        }
    }
}
