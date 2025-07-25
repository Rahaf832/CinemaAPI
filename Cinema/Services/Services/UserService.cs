using Microsoft.EntityFrameworkCore;
using CinemaAPI.DTO.ReadDTO;
using CinemaAPI.DTO.UpdateDTO;
using AutoMapper;
using CinemaAPI.Services.Interfaces;
using CinemaAPI.Data;

namespace CinemaAPI.Services.Services
{
    public class UserService:IUser
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public UserService(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<UserReadDTO>> GetUsers()
        {
            var users = await _context.Users
                .Include(u => u.Bookings).ToListAsync();
            
            var result=_mapper.Map<List<UserReadDTO>>(users);
            return result;
        }
        public async Task<UserReadDTO> GetUserById(int id)
        {
            var user = await _context.Users
                .Include(u => u.Bookings)
                .FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return null;
            var result=_mapper.Map<UserReadDTO>(user);
            return result;
        }
        public async Task<bool>UpdateUser(int id ,UserUpdateDto userUpdate)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)return false;
            user.Name=userUpdate.Name;
            user.Email=userUpdate.Email;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
