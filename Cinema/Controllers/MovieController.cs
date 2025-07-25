using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CinemaAPI.DTO.ReadDTO;
using CinemaAPI.DTO.CreateDTO;
using CinemaAPI.DTO.UpdateDTO;
using CinemaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace CinemaAPI.Controllers
{
    [Authorize]
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
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieReadDTO>> GetMovieById(int id)
        {
            var movie = await _movieSrevice.GetMovieById(id);
            if (movie==null) { return NotFound("Movie not found ."); }
            return Ok(movie);
        }
        [HttpPost]
        public async Task<ActionResult<int>> AddMovie(MovieCreateDTO movieCreate)
        {
            var movie = await _movieSrevice.AddMovie(movieCreate);
            return Ok( new { message = "Movie added successfuly", MovieId = movie });
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateMovie(int id ,MovieUpdateDTO movieUpdate)
        {
            var movie= await _movieSrevice.UpdateMovie(id, movieUpdate);
            if (!movie) { return NotFound("Movie not found ."); }
            return Ok("Movie updated successfully .");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteMovie(int id)
        {
            var movie =await _movieSrevice.DeleteMovie(id);
            if (!movie) { return NotFound("Movie not found ."); }
            return Ok("Movie deleted successfully .");

        }
    }
}
