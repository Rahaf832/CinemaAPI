using Microsoft.EntityFrameworkCore;
using CinemaAPI.Services.Interfaces;
using CinemaAPI.DTO.CreateDTO;
using CinemaAPI.Models;
using CinemaAPI.DTO.UpdateDTO;
using CinemaAPI.DTO.ReadDTO;
using CinemaAPI.Data;
using AutoMapper;
namespace CinemaAPI.Services.Services
{
    public class RoleServices:IRole
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public RoleServices(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RoleDTORead>> GetRoles()
        {
            var roles = await _context.Roles
                .Include(r => r.Users)
                .ToListAsync();
            return _mapper.Map<List<RoleDTORead>>(roles);
        }
        public async Task<RoleDTORead> GetRoleById(int id)
        {
            var role = await _context.Roles
                .Include(r => r.Users)
                .FirstOrDefaultAsync(r=>r.Id==id);
            if (role == null)
            {
                return null;
            }
            return _mapper.Map<RoleDTORead>(role);
        }
        public async Task<int> AddRole(RoleDTO roleDTO)
        {
            var role = _mapper.Map<Role>(roleDTO);
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return role.Id;

        }
        public async Task<bool> DeleteRole(int id)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
            if (role == null)
            {
                return false;
            }
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateRole(int id ,RoleDTOUpdate roleDTO)
        {
            var role= await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
            if (role == null)
            {
                return false;
            }
            role.Name=roleDTO.Name;
            await _context.SaveChangesAsync();

            return true;
        }


    }
}
