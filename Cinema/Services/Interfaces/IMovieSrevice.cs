using CinemaAPI.DTO.ReadDTO;
using CinemaAPI.DTO.CreateDTO;
using CinemaAPI.DTO.UpdateDTO;

namespace CinemaAPI.Services.Interfaces
{
    public interface IMovieSrevice
    {
        Task<List<MovieReadDTO>> GetMovies();
        Task<MovieReadDTO> GetMovieById(int id);
        Task<int> AddMovie(MovieCreateDTO create);
        Task<bool> UpdateMovie(int id, MovieUpdateDTO updateDTO);
        Task<bool> DeleteMovie(int id);
        
    }
}
