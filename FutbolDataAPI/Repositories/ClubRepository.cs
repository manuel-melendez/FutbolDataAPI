using FutbolDataAPI.Data;
using FutbolDataAPI.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace FutbolDataAPI.Repositories
{
    public class ClubRepository : IClubRepository
    {
        private readonly ApplicationDbContext _context;

        public ClubRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Club> CreateClub(Club club)
        {
            _context.Clubs.Add(club);
            await _context.SaveChangesAsync();

            return club;
        }

        public async Task DeleteClub(int clubId)
        {
            Log.Information("Repo: Deleting club with id {clubId}", clubId);
            var club = await _context.Clubs.FirstOrDefaultAsync(c => c.ClubId == clubId);
            if (club != null)
            {
                _context.Clubs.Remove(club);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Club> GetClubById(int clubId)
        {
            Log.Information("Repo: Getting club with id {clubId}", clubId);
            var club = await _context.Clubs.FirstOrDefaultAsync(c => c.ClubId == clubId);
            return club;
        }

        public async Task<IEnumerable<Club>> GetClubs()
        {
            Log.Information("Repo: Getting all clubs");
            var clubs = await _context.Clubs.ToListAsync();
            return clubs;
        }

        public async Task<Club> UpdateClub(int clubId, Club club)
        {
            Log.Information("Repo: Updating club {@club}", club);
            var existingClub = await _context.Clubs.FirstOrDefaultAsync(c => c.ClubId == clubId);
            if (existingClub != null)
            {
                existingClub.Name = club.Name;
                existingClub.StadiumName = club.StadiumName;
                existingClub.City = club.City;
                existingClub.Country = club.Country;

                await _context.SaveChangesAsync();
                return existingClub;
            }
            return null;
        }
    }
}
