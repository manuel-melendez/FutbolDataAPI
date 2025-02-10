using FutbolDataAPI.Models;
using FutbolDataAPI.Repositories;
using Serilog;

namespace FutbolDataAPI.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<Player> CreatePlayer(Player player)
        {
            Log.Information("Service: Creating player {@player}", player);
            var newPlayer = await _playerRepository.CreatePlayer(player);
            return newPlayer;
        }

        public async Task DeletePlayer(int playerId)
        {
            Log.Information("Service: Deleting player with id {playerId}", playerId);
            await _playerRepository.DeletePlayer(playerId);
        }

        public async Task<Player> GetPlayerById(int playerId)
        {
            Log.Information("Service: Getting player with id {playerId}", playerId);
            var exisitingPlayer = await _playerRepository.GetPlayerById(playerId);
            return exisitingPlayer;
        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            Log.Information("Service: Getting all players");
            var players = await _playerRepository.GetPlayers();
            return players;
        }

        public async Task<Player> UpdatePlayer(int playerId, Player player)
        {
            Log.Information("Service: Updating player {@player}", player);
            var existingPlayer = await _playerRepository.UpdatePlayer(playerId, player);
            return existingPlayer;
        }
    }
}
