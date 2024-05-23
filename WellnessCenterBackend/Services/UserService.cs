using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WellnessCenterBackend.Database;
using WellnessCenterBackend.Database.Entities;
using WellnessCenterBackend.Exceptions;
using WellnessCenterBackend.Models;

namespace WellnessCenterBackend.Services
{
    public interface IUserService
    {
        void RemoveUser(int id);
        public List<UserDto> GetUsers(PaginationInfoDto dto);
        void UpdateRole(UpdateRoleDto dto);
        List<Role> GetRoles();
        object GetUser(int id);
        void UpdateUser(int id, UpdateUserDto dto);
    }
    public class UserService : IUserService
    {
        private readonly MyDbContext _context;
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;

        public delegate T GetClass<T>(int id);


        public UserService(MyDbContext context, ILogger<UserService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public List<UserDto> GetUsers(PaginationInfoDto dto)
        {
            var users = _context.Users.Include(u => u.Role).Skip(dto.PageSize * (dto.PageNumber -1)).Take(dto.PageSize).ToList();
            
            if (users == null)
            {
                throw new NotFoundException("User not found");
            }
            List<UserDto> usersDto = _mapper.Map<List<UserDto>>(users);
            return usersDto;
        }
        public object GetUser(int id)
        {
            var user = GetUserById(id);

            return user;
        }

        public void RemoveUser(int id)
        {
            var user = GetUserById(id);

            _logger.LogWarning($"Remove user {id}");
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public void UpdateRole(UpdateRoleDto dto)
        {
            var user = GetUserById(dto.UserId);

            GetRoleById(dto.RoleId);

            _mapper.Map(dto, user);
            _context.SaveChanges();
        }

        private void GetRoleById(int roleId)
        {
            var targetRole = _context.Roles.SingleOrDefault(r => r.Id == roleId);

            if (targetRole == null)
            {
                throw new NotFoundException($"Role with Id: {roleId} not found");
            }
        }

        public User GetUserById(int id)
        {
            var user = _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new NotFoundException("Not found");
            }
            return user;
        }

        public void UpdateUser(int id, UpdateUserDto dto)
        {
            var user = _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new NotFoundException("Nie znaleziono użytkownika o podanym ID!");
            }
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.Phone = dto.PhoneNumber;

            _context.SaveChanges();
        }
    }

}
