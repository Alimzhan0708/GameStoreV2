using Application.Contracts.Output;
using Domain.Entities;

namespace Application.Services
{
    internal class GenreService
    {
        private readonly IGenericRepository<Genre> _genreService;

        public GenreService(IGenericRepository<Genre> genreService)
        {
            _genreService = genreService;
        }
    }
}
