using Application.Dtos.Game;
using Domain.Entities;

namespace Application.Contracts.Input
{
    public interface IGameService
    {
        Task<List<GameDto>> ListAsync(CancellationToken cancellationToken = default);
        Task<GameDto> GetGameByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task CreateGameAsync(CreateGameDto dto, CancellationToken cancellationToken = default);
        Task UpdateGameAsync(UpdateGameDto dto, CancellationToken cancellationToken = default);
        Task DeleteGameAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
