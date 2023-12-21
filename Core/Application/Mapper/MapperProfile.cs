using Application.Dtos.Game;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    internal class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateGameDto, Game>();
            CreateMap<UpdateGameDto, Game>();
            CreateMap<Game, GameDto>().ReverseMap();
        }
    }
}
