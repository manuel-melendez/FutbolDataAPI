using FutbolDataAPI.Models;

namespace FutbolDataAPI.Services
{
    public interface IClubService
    {
        Task<IEnumerable<Club>> GetClubs();
        Task<Club> GetClubById(int clubId);
        Task<Club> CreateClub(Club club);
        Task<Club> UpdateClub(Club club);
        Task DeleteClub(int clubId);
    }
}
