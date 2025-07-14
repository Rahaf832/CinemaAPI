using CinemaAPI.Models;
using CinemaAPI.DTO.ReadDTO;
using CinemaAPI.DTO.CreateDTO;

namespace CinemaAPI.Services
{
    public interface  IMovieSrevice
    {
        Task<List<MovieReadDTO>> GetMovies();
        Task<int> AddMovie(MovieCreateDTO create);
    }
}
