using GameCatalogService.Domain.Models;

namespace GameCatalogService.Domain.Interfaces
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetGamesAsync();
    }
}
