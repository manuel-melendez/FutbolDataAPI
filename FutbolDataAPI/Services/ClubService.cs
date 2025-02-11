using FutbolDataAPI.Models;
using FutbolDataAPI.Repositories;
using Serilog;

namespace FutbolDataAPI.Services
{
    public class ClubService : IClubService
    {
        private readonly IClubRepository _clubRepository;
        private readonly IPlayerRepository _playerRepository;

        public ClubService(IClubRepository clubRepository, IPlayerRepository playerRepository)
        {
            _clubRepository = clubRepository;
            _playerRepository = playerRepository;
        }
        public async Task<Club> CreateClub(Club club)
        {
            Log.Information("Service: Creating club {@club}", club);
            var newClub = await _clubRepository.CreateClub(club);
            return newClub;
        }

        public async Task DeleteClub(int clubId)
        {
            Log.Information("Service: Deleting club with id {clubId}", clubId);
            await _clubRepository.DeleteClub(clubId);
        }

        public async Task<Club> GetClubById(int clubId)
        {
            Log.Information("Service: Getting club with id {clubId}", clubId);
            var existingClub = await _clubRepository.GetClubById(clubId);
            return existingClub;
        }

        public async Task<IEnumerable<Club>> GetClubs()
        {
            Log.Information("Service: Getting all clubs");
            var clubs = await _clubRepository.GetClubs();
            return clubs;
        }

        public async Task<Club> UpdateClub(int clubId, Club club)
        {
            Log.Information("Service: Updating club {@club}", club);
            var updatedClub = await _clubRepository.UpdateClub(clubId, club);
            return updatedClub;
        }

        public async Task AddPlayerToClub(int clubId, int playerId)
        {
            Log.Information("Service: Adding player with id {playerId} to club with id {clubId}", playerId, clubId);
            var club = await _clubRepository.GetClubById(clubId);
            var player = await _playerRepository.GetPlayerById(playerId);

            if (club != null && player != null)
            {
                club.Players.Add(player);
                await _clubRepository.SaveChangesAsync();
            }
        }

        public async Task RemovePlayerFromClub(int clubId, int playerId)
        {
            Log.Information("Service: Removing player with id {playerId} from club with id {clubId}", playerId, clubId);
            Log.Information("Service: Adding player with id {playerId} to club with id {clubId}", playerId, clubId);
            var club = await _clubRepository.GetClubById(clubId);
            var player = await _playerRepository.GetPlayerById(playerId);

            if (club != null && player != null)
            {
                club.Players.Remove(player);
                await _clubRepository.SaveChangesAsync();
            }
        }
    }
}
