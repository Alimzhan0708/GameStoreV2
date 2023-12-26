using Application.Contracts.Input;
using Application.Dtos.Game;
using Application.Exceptions.Common;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GameStoreV2.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("ListGames")]
        public async Task<List<GameDto>> ListGamesAsync(CancellationToken cancellationToken = default)
        {
            return await _gameService.ListAsync(cancellationToken);
        }
        

        [HttpGet("GetGameById")]
        public async Task<GameDto> GetGameByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _gameService.GetGameByIdAsync(id, cancellationToken);
        }

        [ProducesErrorResponseType(typeof(ApiException))]
        [HttpPost("CreateGame")]
        public async Task<ActionResult> CreateGameAsync(CreateGameDto dto, CancellationToken cancellationToken = default)
        {
            await _gameService.CreateGameAsync(dto, cancellationToken);

            return Ok();
        }

        [HttpPut("UpdateGame")]
        public async Task<ActionResult> UpdateGameAsync(UpdateGameDto dto, CancellationToken cancellationToken = default)
        {
            await _gameService.UpdateGameAsync(dto, cancellationToken);

            return Ok();
        }

        [HttpDelete("DeleteGame")]
        public async Task DeleteGameAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _gameService.DeleteGameAsync(id, cancellationToken);
        }
    }
}
