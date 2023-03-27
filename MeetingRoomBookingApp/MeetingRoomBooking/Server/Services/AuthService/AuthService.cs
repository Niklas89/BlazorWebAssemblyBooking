using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace MeetingRoomBooking.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly BookingRoomContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(BookingRoomContext context,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        public async Task<ServiceResponse<string>> Login(string email, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Mail.ToLower().Equals(email.ToLower()));
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
            }
            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong password.";
            }
            else
            {
                // find the user role
                var userRole = await _context.UserRoles.FirstOrDefaultAsync(u => u.IdUser == user.Id);
                var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == userRole.IdRole);
                response.Data = CreateToken(user, role.RoleName);
            }
            
            return response;
        }

        public async Task<ServiceResponse<Guid>> Register(User user, string password)
        {
            if (await UserExists(user.Mail))
            {
                return new ServiceResponse<Guid>
                {
                    Success = false,
                    Message = "User already exists."
                };
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
      
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            UserRole userRole = new UserRole
            {
                IdRole = 1,
                IdUser = user.Id
            };

            _context.UserRoles.Add(userRole);

            await _context.SaveChangesAsync();

            return new ServiceResponse<Guid> { Data = user.Id, Message = "Registration successful!" };
        }

        public async Task<bool> UserExists(string email)
        {
            if (await _context.Users.AnyAsync(user => user.Mail.ToLower()
                 .Equals(email.ToLower())))
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash =
                    hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user, string roleName)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Mail),
                new Claim(ClaimTypes.Role, roleName)
            };

            // get the secret key from the appsettings.json file and convert it to bytes
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));
          
            // create a new instance of signing credentials with the secret key
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            // create a token
            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public async Task<ServiceResponse<bool>> ChangePassword(Guid userId, string newPassword)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "User not found."
                };
            }

            CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true, Message = "Password has been changed." };
        }
    }
}