using CinemaAPI.DTO.ReadDTO;
using CinemaAPI.DTO.UpdateDTO;

namespace CinemaAPI.Services.Interfaces
{
    public interface IUser
    {
        Task<List<UserReadDTO>> GetUsers();
        Task<UserReadDTO> GetUserById(int id);
        Task<bool> UpdateUser(int id, UserUpdateDto user);
        Task<bool> DeleteUser(int id);
    }
}
