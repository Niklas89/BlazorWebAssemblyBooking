namespace MeetingRoomBooking.Server.Services.UserService
{
    public class UserService : IUserService
    {

            private readonly BookingRoomContext _context;

            public UserService(BookingRoomContext context)
            {
                _context = context;
            }

        public async Task<ServiceResponse<List<UserDto>>> GetUsers()
        {
            List<UserDto> users = new List<UserDto>();

            users = await _context.UserRoles.Select(b => new UserDto
            {
                Id = b.IdUserNavigation.Id,
                FullName = b.IdUserNavigation.FullName,
                Mail = b.IdUserNavigation.Mail,
                IdUserRole = b.Id,
                IdRole = b.IdRoleNavigation.Id,
                RoleName = b.IdRoleNavigation.RoleName
            }).ToListAsync();

            return new ServiceResponse<List<UserDto>>
            {
                Data = users
            };

        }

        public async Task<ServiceResponse<UserDto>> CreateUser(UserDto userDto)
        {
            if (await UserExists(userDto.Mail))
            {
                return new ServiceResponse<UserDto>
                {
                    Success = false,
                    Message = "User already exists."
                };
            }

            CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User user = new User
            {
                FullName = userDto.FullName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Mail = userDto.Mail,
                
            };
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            // Select inserted user in order to get his id which was generated in the db
            var dbUserMail = await _context.Users.FirstOrDefaultAsync(u => u.Mail == userDto.Mail);
            userDto.Id = dbUserMail.Id;

            UserRole userRole = new UserRole
            {
                Id= userDto.IdUserRole,
                IdRole = userDto.IdRole,
                IdUser = userDto.Id
            };
            _context.UserRoles.Add(userRole); 

            await _context.SaveChangesAsync(); 

            return new ServiceResponse<UserDto> { Data = userDto, Message = "User registration successful!" };
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


        public async Task<ServiceResponse<UserDto>> UpdateUser(UserDto userDto)
        {
            


            // Select the user field from the database (dbUser) that corresponds to the user that we update
            var dbUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userDto.Id);

            if (dbUser == null)
            {
                return new ServiceResponse<UserDto>
                {
                    Success = false,
                    Message = "No user found in the database"
                };
            }

            dbUser.FullName = userDto.FullName;
            dbUser.Mail = userDto.Mail;

            

            // Select the userRole field from the database (dbUserRole) that corresponds to the userRole that we update
            var dbUserRole = await _context.UserRoles.FirstOrDefaultAsync(u => u.IdUser == userDto.Id);

            var dbRole = await _context.Roles.FirstOrDefaultAsync(u => u.Id == userDto.IdRole);

            if (dbUserRole == null)
            {
                return new ServiceResponse<UserDto>
                {
                    Success = false,
                    Message = "No role found in the database"
                };
            }

            dbUserRole.IdRole = userDto.IdRole;
            dbUserRole.IdRoleNavigation = dbRole;
            dbUserRole.IdUserNavigation = dbUser;


            _context.Users.Update(dbUser);
            _context.UserRoles.Update(dbUserRole);
            await _context.SaveChangesAsync();


            return new ServiceResponse<UserDto> { Data = userDto };
        }


        public async Task<ServiceResponse<bool>> DeleteUser(Guid userId)
        {
            var dbuser = await _context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
            if (dbuser != null)
            {
               var userRole = await _context.UserRoles.Where(r => r.IdUser == userId).ToListAsync();
                foreach(UserRole r in userRole)
                {
                    _context.UserRoles.Remove(r);
                }

                var bookings = await _context.Bookings.Where(b => b.CreationUserId== userId).ToListAsync();
                 foreach (Booking b in bookings)
                 {
                     _context.Bookings.Remove(b);
                 }

                _context.Users.Remove(dbuser);
                await _context.SaveChangesAsync();
            }
            else
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "User not found."
                };
            }

          
            return new ServiceResponse<bool> { Data = true };
        }


    }
    
}