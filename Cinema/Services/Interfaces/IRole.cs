using CinemaAPI.DTO.CreateDTO;
using CinemaAPI.DTO.UpdateDTO;
using CinemaAPI.DTO.ReadDTO;
namespace CinemaAPI.Services.Interfaces
{
    public interface IRole
    {
        Task<List<RoleDTORead>> GetRoles();
        Task<RoleDTORead> GetRoleById(int id);
        Task<int> AddRole(RoleDTO roleDTO);
        Task <bool> DeleteRole(int id);
        Task<bool> UpdateRole(int id ,RoleDTOUpdate roleDTO);
    }
}
