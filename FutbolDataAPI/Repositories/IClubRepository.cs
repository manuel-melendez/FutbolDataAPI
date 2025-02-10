using FutbolDataAPI.Models;

namespace FutbolDataAPI.Repositories
{
    public interface IClubRepository
    {
        Task<IEnumerable<Club>> GetClubs();
        Task<Club> GetClubById(int clubId);
        Task<Club> CreateClub(Club club);
        Task<Club> UpdateClub(int clubId, Club club);
        Task DeleteClub(int clubId);
        Task SaveChangesAsync();
    }
}
