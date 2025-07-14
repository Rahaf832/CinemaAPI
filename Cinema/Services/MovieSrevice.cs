using Microsoft.EntityFrameworkCore;
using CinemaAPI.DTO.ReadDTO;
using CinemaAPI.Models;
using CinemaAPI.Data;
using AutoMapper;
using CinemaAPI.DTO.CreateDTO;

namespace CinemaAPI.Services
{
    public class MovieSrevice : IMovieSrevice
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MovieSrevice(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MovieReadDTO>> GetMovies()
        {
            var movie = await _context.Movies
                .Include(m => m.ShowTimes)
                .ToListAsync();
            return _mapper.Map<List<MovieReadDTO>>(movie);
        }

        public async Task<int> AddMovie(MovieCreateDTO createMovie)
        {
            var movie=_mapper.Map<Movie>(createMovie);
            _context.Movies.Add(movie);
            
            await _context.SaveChangesAsync();
            
            return movie.Id;
        }
    }
}
