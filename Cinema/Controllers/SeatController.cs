using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CinemaAPI.DTO.CreateDTO;
using CinemaAPI.DTO.ReadDTO;
using CinemaAPI.DTO.UpdateDTO;
using CinemaAPI.Services.Interfaces;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly ISeat _seat;
        public SeatController(ISeat seat)
        {
            _seat = seat;
        }   
        [HttpGet]
        public async Task<ActionResult<List<SeatRead>>> GetSeats()
        {
            var seats = await _seat.GetSeats();
            return Ok(seats);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SeatRead>> GetSeatById(int id)
        {
            var seat = await _seat.GetSeatById(id);
            if (seat == null)
            {
                return NotFound("Seat not found .");
            }
            return Ok(seat);
        }
        [HttpPost]
        public async Task<ActionResult<int>> AddSeat(SeatCreate seatCreat)
        {
            var seat =await _seat.AddSeat(seatCreat);
            return Ok(new { message = "Seat added successfully .", seat });
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateSeat(int id ,SeatUpdate seatUpdate)
        {
            var seat=await _seat.UpdateSeat(id,seatUpdate);
            if (!seat) { return NotFound("Seat not found ."); }
            return Ok("Seat Updated Successfully .");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteSeat(int id)
        {
            var seat=await _seat.DeleteSeat(id);
            if (!seat) { return NotFound("Seat not found ."); }
            return Ok("Seat Deleted Successfully .");

        }
        //Test
    }
}
