using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WellnessCenterBackend.Exceptions;
using WellnessCenterBackend.Models;
using WellnessCenterBackend.Seeders;
using WellnessCenterBackend.Services;

namespace WellnessCenterBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;
        private readonly IAccountSeeder _seeder;

        public AccountController(IAccountService service, IAccountSeeder seeder)
        {
            _service = service;
            _seeder = seeder;
        }
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto dto)
        {
            string token = _service.GenerateJWT(dto);
            var jsonToken = JsonSerializer.Serialize(token);
            return Ok(jsonToken);
        }
        [HttpPost("register")]
        public ActionResult Registration([FromBody] RegisterUserDto dto)
        {
            _service.RegisterUser(dto);
            return Ok();
        }
        [HttpPost("register/admin")]
        public ActionResult<AdminAccountDto> CreateAdmin()
        {
            var adminAccount = _seeder.TryCreateAdminAccount();
            return Ok(adminAccount);
        }
    }
}
