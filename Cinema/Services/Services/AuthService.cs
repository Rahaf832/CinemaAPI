using CinemaAPI.DTO.UserDTO;
using CinemaAPI.Data;
using CinemaAPI.Services.Interfaces;
using CinemaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace CinemaAPI.Services.Services
{
    public class AuthService:IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(AppDbContext context,IConfiguration configuration)
        { 
            _context = context; 
            _configuration = configuration; 
        }

        public async Task<string> Register(UserRegisterDTO userRegister)
        {
            //1) Check is Email is already exicted
            var register=await _context.Users.FirstOrDefaultAsync(r=>r.Email==userRegister.Email);
            if (register != null)
            {
                throw new ArgumentException("Email is already registered .");
            }
            //2) Do Hash for Password
            string passwardHash = HashPassword(userRegister.Password);

            //3) new user
            var user = new User
            {
                Name = userRegister.Name,
                Email = userRegister.Email,
                PasswordHash = passwardHash,
                RoleId = 2  //Make it always User 
            };

            //4) Add it to database
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            //5) Make Taken
            var token = GenerateJwtToken(user);

            return token;
        }

        // HashPassword Function
        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
        //GenerateJwtToken Function
        private string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role?.Name ?? "User") // نضيف الدور بالتوكن
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string>Login(UserLoginDTO userLogin)
        {
            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == userLogin.Email);
            if (user == null)
            {
                throw new Exception("Invalid email or password.");
            }
            string passwordHash=HashPassword(userLogin.Password);
            if (user.PasswordHash != passwordHash)
            {
                throw new Exception("Invalid email or password.");
            }
            var token = GenerateJwtToken(user);
            return token;
        }

    }
}
