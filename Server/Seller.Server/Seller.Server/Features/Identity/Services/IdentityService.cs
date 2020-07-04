﻿namespace Seller.Server.Features.Identity.Services
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Microsoft.IdentityModel.Tokens;
    using Interfaces;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Data;
    using Data.Models;
    public class IdentityService : IIdentityService
    {
        private const string InvalidErrorMessage = "Invalid credentials.";

        private readonly UserManager<User> userManager;
        private readonly SellerDbContext context;

        public IdentityService(UserManager<User> userManager, SellerDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        public async Task<bool> CreateUserSeller(string firstName, string lastName, string userId)
        {

            var userSeller = new UserSeller
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = firstName,
                LastName = lastName,
                UserId = userId
            };

            context.Add(userSeller);
            int result = await context.SaveChangesAsync();

            if (result == 0) return false;
            return true;
        }

        public async Task<User> Register(string email, string username, string password, string phoneNumber)
        {
            var user = new User()
            {
                UserName = username,
                Email = email,
                PhoneNumber = phoneNumber,
            };

            await this.userManager.CreateAsync(user, password);

            if (userManager.Users.Count() == 1)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }

            await userManager.AddToRoleAsync(user, "User");

            return user;
        }
        public string GenerateJwtToken(string userId, string userName, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Name, userName),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
