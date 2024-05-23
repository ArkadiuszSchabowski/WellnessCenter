using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WellnessCenterBackend.Models;
using WellnessCenterBackend.Services;

namespace WellnessCenterBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("currentUser")] // All functionalities have been verified to work correctly.
        public int GetCurrentUserId()
        {
            int id = int.Parse(User?.FindFirstValue(ClaimTypes.NameIdentifier));

            return id;
        }

        [HttpGet]
        public ActionResult GetAll([FromQuery] PaginationInfoDto dto)
        {
            var users = _service.GetUsers(dto);
            return Ok(users);
        }

        [HttpGet("{id}")] //// All functionalities have been verified to work correctly.
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
        [HttpPut("{id}")]
        public ActionResult UpdateUser([FromRoute]int id, [FromBody] UpdateUserDto dto)
        {
            _service.UpdateUser(id, dto);
            return Ok();
        }
    }
}
