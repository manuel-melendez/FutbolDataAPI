using FutbolDataAPI.Models;
using FutbolDataAPI.Repositories;

namespace FutbolDataAPI.Services
{
    public class ClubService : IClubService
    {
        private readonly IClubRepository _clubRepository;

        public ClubService(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }
        public async Task<Club> CreateClub(Club club)
        {
            var newClub = await _clubRepository.CreateClub(club);
            return newClub;
        }

        public async Task DeleteClub(int clubId)
        {
            await _clubRepository.DeleteClub(clubId);
        }

        public async Task<Club> GetClubById(int clubId)
        {
            var existingClub = await _clubRepository.GetClubById(clubId);
            return existingClub;
        }

        public async Task<IEnumerable<Club>> GetClubs()
        {
            var clubs = await _clubRepository.GetClubs();
            return clubs;
        }

        public async Task<Club> UpdateClub(Club club)
        {
            var updatedClub = await _clubRepository.UpdateClub(club);
            return updatedClub;
        }
    }
}
