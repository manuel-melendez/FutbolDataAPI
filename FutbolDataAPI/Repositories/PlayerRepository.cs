using FutbolDataAPI.Data;
using FutbolDataAPI.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace FutbolDataAPI.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDbContext _context;
        public PlayerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Player> CreatePlayer(Player player)
        {
            Log.Information("Repo: Creating player {@player}", player);
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task DeletePlayer(int playerId)
        {
            Log.Information("Repo: Deleting player with id {playerId}", playerId);
            var existingPlayer = await _context.Players.FirstOrDefaultAsync(p => p.PlayerId == playerId);
            if (existingPlayer != null)
            {
                _context.Players.Remove(existingPlayer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Player> GetPlayerById(int playerId)
        {
            Log.Information("Repo: Getting player with id {playerId}", playerId);
            var player = await _context.Players.FirstOrDefaultAsync(p => p.PlayerId == playerId);
            return player;
        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            Log.Information("Repo: Getting all players");
            var players = await _context.Players.ToListAsync();
            return players;
        }

        public async Task<Player> UpdatePlayer(int playerId, Player player)
        {
            Log.Information("Repo: Updating player {@player}", player);
            var existingPlayer = await _context.Players.FirstOrDefaultAsync(p => p.PlayerId == playerId);
            if (existingPlayer != null)
            {
                existingPlayer.FirstName = player.FirstName;
                existingPlayer.LastName = player.LastName;
                existingPlayer.Position = player.Position;
                existingPlayer.Number = player.Number;

                await _context.SaveChangesAsync();
                return existingPlayer;
            }

            return null;
        }
    }
}
