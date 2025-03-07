﻿using FutbolDataAPI.Models;

namespace FutbolDataAPI.Services
{
    public interface IClubService
    {
        Task<IEnumerable<Club>> GetClubs();
        Task<Club> GetClubById(int clubId);
        Task<Club> CreateClub(Club club);
        Task<Club> UpdateClub(int clubId, Club club);
        Task DeleteClub(int clubId);
        Task AddPlayerToClub(int clubId, int playerId);
        Task RemovePlayerFromClub(int clubId, int playerId);
    }
}
