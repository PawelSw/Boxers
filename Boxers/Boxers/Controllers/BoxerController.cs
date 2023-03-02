using AutoMapper;
using Boxers.Entities;
using Boxers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Boxers.Controllers
{
    [Route("api/boxers")]
    [ApiController]

    public class BoxerController : ControllerBase
    {
        private readonly BoxerDbContext _dbcontext;
        private readonly IMapper _mapper;


        public BoxerController(BoxerDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;  
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Boxer>> GetAll()
        {
            var boxers = _dbcontext
                .Boxers
                .Include(x => x.Trainer)
                .Include(x => x.Achievements)
                .ToList();

            var boxersDto = _mapper.Map<List<BoxerDto>>(boxers);
            return Ok(boxersDto);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Boxer>> GetById([FromRoute] int id)
        {
            var boxer = _dbcontext
                .Boxers
                .Include(x => x.Trainer)
                .Include(x => x.Achievements)
                .FirstOrDefault(x => x.Id == id);

            if (boxer == null)
            {
                return NotFound();
            }

            var boxerDto = _mapper.Map<BoxerDto>(boxer);
            return Ok(boxerDto);          
        }

        //[HttpPut("{id}")]
        //public ActionResult Update([FromBody] UpdateRestaurantDto dto, [FromRoute] int id)
        //{

        //    _restaurantService.Update(id, dto);

        //    return Ok();
        //}

        //[HttpDelete("{id}")]
        //public ActionResult Delete([FromRoute] int id)
        //{
        //    _restaurantService.Delete(id);

        //    return NoContent();
        //}



        //[HttpGet("{id}")]
        //[AllowAnonymous]
        //public ActionResult<RestaurantDto> Get([FromRoute] int id)
        //{
        //    var restaurant = _restaurantService.GetById(id);

        //    return Ok(restaurant);
        //}
    }
}
