using Contact.Service.Core.Models;
using Contact.Service.Core.Settings;
using Contact.Service.Core.Utils;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Service.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordHasher<User> passwordHasher;
        private readonly AuthenticationSettings authenticationSettings;

        public UserService(IUserRepository userRepository,IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
            this.authenticationSettings = authenticationSettings;
        }

        public async Task<int> RegisterAsync(User user, string password)
        {
            var hashPassword = passwordHasher.HashPassword(user, password);

            user.SetPassword(hashPassword);

            return await userRepository.AddAsync(user);
        }

        public async Task<string> LoginAsync(LoginUser userDTO)
        {
            var user = await userRepository.GetUserByEmail(userDTO.Email);

            var result = passwordHasher.VerifyHashedPassword(user, user.HashPassword, userDTO.Password);

            if (result is PasswordVerificationResult.Failed)
            {
                throw new ArgumentException("Invalid username or password");
            }

            return JwtMethods.GenerateJwt(user, authenticationSettings);
        }
    }
}
