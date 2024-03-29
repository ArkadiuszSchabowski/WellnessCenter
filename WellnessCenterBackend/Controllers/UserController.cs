﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WellnessCenterBackend.Models;
using WellnessCenterBackend.Services;

namespace WellnessCenterBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult GetAll([FromQuery] PaginationInfoDto dto)
        {
            var users = _service.GetUsers(dto);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult GetUser([FromRoute] int id)
        {
            var user = _service.GetUser(id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveUser([FromRoute] int id)
        {

            _service.RemoveUser(id);
            return NoContent();
        }
        [HttpGet("role")]
        public ActionResult GetRoles()
        {
            var roles = _service.GetRoles();
            return Ok(roles);
        }
        [HttpPatch("{dto.UserId}/role/{dto.RoleId}")]
        public ActionResult UpdateRole([FromRoute] UpdateRoleDto dto)
        {
            _service.UpdateRole(dto);
            return Ok();
        }
    }
}
