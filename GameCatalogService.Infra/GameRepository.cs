using GameCatalogService.Domain.Interfaces;
using GameCatalogService.Domain.Models;
using GameCatalogService.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace GameCatalogService.Infra
{
    public class GameRepository : IGameRepository
    {
        private readonly GameHubDbContext _dbContext;

        public GameRepository(GameHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            return await _dbContext.Games.ToListAsync();
        }
    }
}
