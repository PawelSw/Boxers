using AutoMapper;
using Boxers.Entities;
using Boxers.Models;
using Boxers.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Boxers.Controllers
{
    [Route("api/boxers")]
    [ApiController]

    public class BoxerController : ControllerBase
    {
        private readonly IBoxerService _iboxerService;

        public BoxerController(IBoxerService iboxerService)
        {
            _iboxerService = iboxerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Boxer>> GetAll()
        {
            var boxersDto = _iboxerService.GetAll();
            return Ok(boxersDto);
        }

        [HttpGet("{id}")]
        public ActionResult<Boxer> GetById([FromRoute] int id)
        {
            var boxer = _iboxerService.GetById(id);
            return Ok(boxer);
        }

        [HttpPost]
        public ActionResult CreateBoxer([FromBody] CreateBoxerDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = _iboxerService.Create(dto);

            return Created($"/boxer/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteById([FromRoute] int id)
        {
            var isDeleted = _iboxerService.DeleteById(id);
            if (isDeleted )
            {
                return NoContent();
            }
           return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateBoxerDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isUpdated = _iboxerService.Update(dto, id);
            if (!isUpdated )
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
