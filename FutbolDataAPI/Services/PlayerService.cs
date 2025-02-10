using FutbolDataAPI.Models;
using FutbolDataAPI.Repositories;

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
            var newPlayer = await _playerRepository.CreatePlayer(player);
            return newPlayer;
        }

        public async Task DeletePlayer(int playerId)
        {
            await _playerRepository.DeletePlayer(playerId);
        }

        public async Task<Player> GetPlayerById(int playerId)
        {
            var exsitingPlayer = await _playerRepository.GetPlayerById(playerId);
            return exsitingPlayer;
        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            var players = await _playerRepository.GetPlayers();
            return players;
        }

        public async Task<Player> UpdatePlayer(Player player)
        {
            var existingPlayer = await _playerRepository.UpdatePlayer(player);
            return existingPlayer;
        }
    }
}
