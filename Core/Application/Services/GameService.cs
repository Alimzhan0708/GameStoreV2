using Application.Contracts.Input;
using Application.Contracts.Output;
using Application.Dtos.Game;
using Application.Exceptions;
using Application.Exceptions.Game;
using Application.Specifications.Game;
using Application.Validators.Game;
using AutoMapper;
using Domain.Entities;
using FluentValidation;

namespace Application.Services
{
    internal class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GameService(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GameDto>> ListAsync(CancellationToken cancellationToken = default)
        {
            var games = await _unitOfWork.GetRepository<Game>().ListAsync(cancellationToken);

            var gamesDtos = _mapper.Map<List<GameDto>>(games);

            return gamesDtos;
        }

        public async Task<GameDto> GetGameByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            var spec = new GamyByNameSpec(name);
            var game = await _unitOfWork.GetRepository<Game>().GetBySpecAsync(spec, cancellationToken);
            var gameDto = _mapper.Map<GameDto>(game);

            return gameDto;
        }

        public async Task<GameDto> GetGameByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var game = await _unitOfWork.GetRepository<Game>().GetByIdAsync(id);

            var gameDto = _mapper.Map<GameDto>(game);  

            return gameDto;
        }

        public async Task CreateGameAsync(CreateGameDto dto, CancellationToken cancellationToken = default)
        {
            var createGameDtoValidator = new CreateGameDtoValidator();
            var validationResult = createGameDtoValidator.Validate(dto);

            if (!validationResult.IsValid) throw new ValidationException("Validation Exception");

            var game = _mapper.Map<Game>(dto);
            await _unitOfWork.GetRepository<Game>().AddAsync(game);
        }

        public async Task UpdateGameAsync(UpdateGameDto dto, CancellationToken cancellationToken = default)
        {
            var game = await _unitOfWork.GetRepository<Game>().GetByIdAsync(dto.Id);

            if (game is null) throw new GameNotFoundException();

            _mapper.Map(dto, game);

            await _unitOfWork.GetRepository<Game>().UpdateAsync(game, cancellationToken);
        }

        public async Task DeleteGameAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var game = await _unitOfWork.GetRepository<Game>().GetByIdAsync(id, cancellationToken);

            if (game is null) throw new GameNotFoundException();

            await _unitOfWork.GetRepository<Game>().DeleteAsync(game, cancellationToken);
        }
    }
}
