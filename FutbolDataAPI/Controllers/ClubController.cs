using FutbolDataAPI.Models;
using FutbolDataAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace FutbolDataAPI.Controllers
{
    [ApiController]
    [Route("api/clubs")]
    public class ClubController : ControllerBase
    {
        private readonly IClubService _clubService;
        private readonly IPlayerService _playerService;

        public ClubController(IClubService clubService, IPlayerService playerService)
        {
            _clubService = clubService;
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetClubs()
        {
            Log.Information("Controller: Getting all clubs");
            var clubs = await _clubService.GetClubs();
            return Ok(clubs);
        }

        [HttpGet("{clubId}")]
        public async Task<IActionResult> GetClubById(int clubId)
        {
            Log.Information("Controller: Getting club with id {clubId}", clubId);
            var club = await _clubService.GetClubById(clubId);
            if (club == null)
            {
                Log.Warning("Controller: Club with id {clubId} not found", clubId);
                return NotFound();
            }
            return Ok(club);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClub(Club club)
        {
            Log.Information("Controller: Creating club {@club}", club);
            var newClub = await _clubService.CreateClub(club);
            return Ok(newClub);
        }

        [HttpPut("{clubId}")]
        public async Task<IActionResult> UpdateClub(int clubId, Club club)
        {
            Log.Information("Controller: Updating club {@club}", club);
            var updatedClub = await _clubService.UpdateClub(clubId, club);
            if (updatedClub == null)
            {
                Log.Warning("Controller: Club with id {clubId} not found", club.ClubId);
                return NotFound();
            }
            return Ok(updatedClub);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteClub(int clubId)
        {
            var club = await _clubService.GetClubById(clubId);
            if (club == null)
            {
                Log.Warning("Controller: Club with id {clubId} not found", clubId);
                return NotFound();
            }

            Log.Information("Controller: Deleting club with id {clubId}", clubId);
            await _clubService.DeleteClub(clubId);
            return NoContent();
        }

        [HttpPost("{clubId}/players/{playerId}")]
        public async Task<IActionResult> AddPlayerToClub(int clubId, int playerId)
        {
            var club = await _clubService.GetClubById(clubId);
            var player = await _playerService.GetPlayerById(playerId);
            if (player == null)
            {
                Log.Warning("Controller: Player with id {playerId} not found", playerId);
                return NotFound();
            }

            if (club == null)
            {
                Log.Warning("Controller: Club with id {clubId} not found", clubId);
                return NotFound();
            }

            Log.Information("Controller: Adding player with id {playerId} to club with id {clubId}", playerId, clubId);
            await _clubService.AddPlayerToClub(clubId, playerId);
            return NoContent();
        }
    }
}
