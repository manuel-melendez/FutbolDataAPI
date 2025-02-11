using AutoMapper;
using FutbolDataAPI.Models;
using FutbolDataAPI.Models.DTOs;
using FutbolDataAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace FutbolDataAPI.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;

        public PlayerController(IPlayerService playerService, IMapper mapper)
        {
            _playerService = playerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            Log.Information("Controller: Getting all players");
            var players = await _playerService.GetPlayers();
            var playersDto = _mapper.Map<IEnumerable<PlayerDTO>>(players);
            return Ok(playersDto);
        }

        [HttpGet("{playerId}")]
        public async Task<IActionResult> GetPlayerById(int playerId)
        {
            Log.Information("Controller: Getting player with id {playerId}", playerId);
            var player = await _playerService.GetPlayerById(playerId);
            if (player == null)
            {
                Log.Warning("Controller: Player with id {playerId} not found", playerId);
                return NotFound();
            }
            return Ok(player);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayers(Player player)
        {
            Log.Information("Controller: Creating player {@player}", player);
            var newPlayer = await _playerService.CreatePlayer(player);
            return Ok(newPlayer);
        }

        [HttpPut("{playerId}")]
        public async Task<IActionResult> UpdatePlayer(int playerId, Player player)
        {
            Log.Information("Controller: Updating player {@player}", player);
            var updatedPlayer = await _playerService.UpdatePlayer(playerId, player);
            if (updatedPlayer == null)
            {
                Log.Warning("Controller: Player with id {playerId} not found", playerId);
                return NotFound();
            }
            return Ok(updatedPlayer);
        }

        [HttpDelete("{playerId}")]
        public async Task<IActionResult> DeletePlayer(int playerId)
        {
            var player = await _playerService.GetPlayerById(playerId);
            if (player == null)
            {
                Log.Warning("Controller: Player with id {playerId} not found", playerId);
                return NotFound();
            }
            Log.Information("Controller: Deleting player with id {playerId}", playerId);
            await _playerService.DeletePlayer(playerId);
            return NoContent();
        }
    }
}
