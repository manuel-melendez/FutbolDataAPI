using FutbolDataAPI.Models;

namespace FutbolDataAPI.Repositories
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetPlayers();
        Task<Player> GetPlayerById(int playerId);
        Task<Player> CreatePlayer(Player player);
        Task<Player> UpdatePlayer(int playerId, Player player);
        Task DeletePlayer(int playerId);
    }
}
