using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CinemaAPI.DTO.ReadDTO;
using CinemaAPI.DTO.CreateDTO;
using CinemaAPI.Services;
namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieSrevice _movieSrevice;

        public MovieController(IMovieSrevice movieSrevice)
        {
            _movieSrevice = movieSrevice;
        }
        [HttpGet]
        public async Task<ActionResult<List<MovieReadDTO>>> GetMovies()
        {
            var movie = await _movieSrevice.GetMovies();
            return Ok(movie);
        }
        [HttpPost]
        public async Task<ActionResult<int>> AddMovie(MovieCreateDTO movieCreate)
        {
            var movie = await _movieSrevice.AddMovie(movieCreate);
            return Ok( new { message = "Movie added successfuly", MovieId = movie });
        }
    }
}
