using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WellnessCenterBackend.Database.Entities;
using WellnessCenterBackend.Models;
using WellnessCenterBackend.Services;

namespace WellnessCenterBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MassageController : ControllerBase
    {
        private readonly IMassageService _service;

        public MassageController(IMassageService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Massage>> GetAll()
        {
            var massages = _service.GetAll();
            return Ok(massages);
        }
        [HttpGet("{id}")]
        public ActionResult<Massage> GetMassage([FromRoute] int id)
        {
            Massage massage = _service.GetMassage(id);
            return Ok(massage);
        }

        [HttpPost]
        [Authorize(Roles = "Manager, Admin")]
        public ActionResult CreateNewTypeMassage([FromBody] CreateMassageDto dto)
        {
            int id = _service.CreateMassage(dto);
            return Created($"api/massage/{id}", null);
        }
        [HttpPatch("{id}")]
        [Authorize(Roles = "Manager, Admin")]
        public ActionResult UpdateMassage([FromBody] UpdateMassageDto dto, [FromRoute] int id)
        {
            var massage = _service.UpdateMassage(dto, id);
            return Ok(massage);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager, Admin")]
        public ActionResult RemoveMassage([FromRoute] int id)
        {
            _service.RemoveMassage(id);
            return NoContent();
        }
    }
}
