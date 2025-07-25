using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CinemaAPI.Services.Interfaces;
using CinemaAPI.DTO.ReadDTO;
using CinemaAPI.DTO.CreateDTO;
using CinemaAPI.DTO.UpdateDTO;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRole _role;
        public RoleController(IRole role)
        {
            _role = role;
        }
        [HttpGet]
        public async Task<ActionResult<List<RoleDTORead>>> GetRoles()
        {
            var roles = await _role.GetRoles();
            return Ok(roles);
        }
        [HttpPost]
        public async Task<ActionResult<int>> AddRole(RoleDTO roleDTO)
        {
            var role = await _role.AddRole(roleDTO);
            return Ok(new { Message = "Role added successfuly", RoleId = role });
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDTORead>> GetRoleById(int id)
        {
            var role= await _role.GetRoleById(id);
            if (role == null)
                return NotFound("Role not found");

            return Ok(role);

        }
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateRole(int id,RoleDTOUpdate roleDTO)
        {
            var role =await _role.UpdateRole(id,roleDTO);
            if (!role)
                return NotFound("Role not found");

            return Ok("Role updated successfully");

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteRole(int id)
        {
            var role=await _role.DeleteRole(id);
            if (!role)
                return NotFound("Role not found");

            return Ok("Role deleted successfully");

        }
    }
}
