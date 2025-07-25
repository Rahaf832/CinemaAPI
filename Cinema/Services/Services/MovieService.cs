using Microsoft.EntityFrameworkCore;
using CinemaAPI.DTO.ReadDTO;
using CinemaAPI.Models;
using CinemaAPI.Data;
using AutoMapper;
using CinemaAPI.DTO.CreateDTO;
using CinemaAPI.DTO.UpdateDTO;
using CinemaAPI.Services.Interfaces;

namespace CinemaAPI.Services.Services
{
    public class MovieService : IMovieSrevice
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MovieService(AppDbContext context, IMapper mapper)
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
        public async Task<MovieReadDTO> GetMovieById(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.ShowTimes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if(movie == null) { return null; }
            var result= _mapper.Map<MovieReadDTO>(movie);
            return result;
        }

        public async Task<int> AddMovie(MovieCreateDTO createMovie)
        {
            var movie = _mapper.Map<Movie>(createMovie);
            _context.Movies.Add(movie);

            await _context.SaveChangesAsync();

            return movie.Id;
        }
        public async Task<bool> UpdateMovie(int id,MovieUpdateDTO movieUpdate)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null) { return false; }
            movie.Title=movieUpdate.Title;
            movie.Genre=movieUpdate.Genre;
            movie.Description=movieUpdate.Description;
            movie.DurationInMinutes=movieUpdate.DurationInMinutes;
            movie.ReleaseDate=movieUpdate.ReleaseDate;
            movie.Language=movieUpdate.Language;
            movie.AgeRestriction=movieUpdate.AgeRestriction;
            movie.PosterUrl=movieUpdate.PosterUrl;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMovie(int id)
        {
            var movie =await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if(movie == null) { return false; }
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
