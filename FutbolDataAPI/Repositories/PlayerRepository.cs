using FutbolDataAPI.Data;
using FutbolDataAPI.Models;
using Microsoft.EntityFrameworkCore;

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
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task DeletePlayer(int playerId)
        {
            var existingPlayer = await _context.Players.FirstOrDefaultAsync(p => p.PlayerId == playerId);
            if (existingPlayer != null)
            {
                _context.Players.Remove(existingPlayer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Player> GetPlayerById(int playerId)
        {
            var player = await _context.Players.FirstOrDefaultAsync(p => p.PlayerId == playerId);
            return player;
        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            var players = await _context.Players.ToListAsync();
            return players;
        }

        public async Task<Player> UpdatePlayer(Player player)
        {
            var existingPlayer = await _context.Players.FirstOrDefaultAsync(p => p.PlayerId == player.PlayerId);
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
