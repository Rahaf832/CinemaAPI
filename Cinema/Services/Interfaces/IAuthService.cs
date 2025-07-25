using CinemaAPI.DTO.UserDTO;

namespace CinemaAPI.Services.Interfaces
{
    public interface IAuthService
    {
        //Register user and return JWT Token
        Task<string> Register(UserRegisterDTO userRegister);

        //Check data and return JWT Token
        Task<string> Login(UserLoginDTO userLogin);
    }
}
