using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CinemaAPI.DTO.ReadDTO;
using CinemaAPI.DTO.UpdateDTO;
using CinemaAPI.Services.Interfaces;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserReadDTO>>> GetUsers()
        {
            var users = await _user.GetUsers();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDTO>> GetUserById(int id)
        {
            var user = await _user.GetUserById(id);
            if (user == null) { return NotFound("User not found ."); }
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            var user = await _user.DeleteUser(id);
            if (!user) { return NotFound("User not found ."); }
            return Ok("User deleted successfully .");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateUser(int id , UserUpdateDto userUpdate)
        {
            var user =await _user.UpdateUser(id, userUpdate);
            if (!user) { return NotFound("User not found ."); }
            return Ok("User Updated successfully .");
        }
    }
}
