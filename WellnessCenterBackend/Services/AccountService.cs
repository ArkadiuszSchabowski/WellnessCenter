﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WellnessCenterBackend.Database;
using WellnessCenterBackend.Database.Entities;
using WellnessCenterBackend.Exceptions;
using WellnessCenterBackend.Models;

namespace WellnessCenterBackend.Services
{
    public interface IAccountService
    {
        string GenerateJWT(LoginDto dto);
        void RegisterUser(RegisterUserDto dto);
    }
    public interface IRegisterAdminService
    {
        public void RegisterAdmin(RegisterUserDto dto);
    }
    public class AccountService : IAccountService, IRegisterAdminService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(MyDbContext context, IMapper mapper, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _context = context;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public string GenerateJWT(LoginDto dto)
        {
            var user = _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Login == dto.Login);

            if (user == null)
            {
                throw new BadRequestException("Błędny e-mail lub hasło");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.HashPassword, dto.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Błędny e-mail lub hasło");
            }
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.Name),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer, _authenticationSettings.JwtIssuer, claims, expires: expires, signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }


        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = _context.Users.FirstOrDefault(u => u.Login == dto.Login);
            if(newUser != null)
            {
                throw new ConflictException("Wybrana nazwa użytkownika jest już zajęta");
            }

            var user = _mapper.Map<User>(dto);

            if(dto.Password != dto.RepeatPassword)
            {
                throw new BadRequestException("Wprowadzone hasła są różne");
            }

            var hashedPassword = _passwordHasher.HashPassword(user, user.HashPassword);
            user.HashPassword = hashedPassword;

            user.RoleId = 1;

            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void RegisterAdmin(RegisterUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            user.RoleId = 3;

            var hashedPassword = _passwordHasher.HashPassword(user, user.HashPassword);
            user.HashPassword = hashedPassword;
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }

}
