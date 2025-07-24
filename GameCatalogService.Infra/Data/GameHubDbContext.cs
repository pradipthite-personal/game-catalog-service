using GameCatalogService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GameCatalogService.Infra.Data
{
    public class GameHubDbContext : DbContext
    {
        public GameHubDbContext(DbContextOptions<GameHubDbContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }
    }
}
