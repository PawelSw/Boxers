using Boxers.Models;
using Boxers.Services;
using Microsoft.AspNetCore.Mvc;

namespace Boxers.Controllers
{
    [Route("api/boxer/{boxerId}/Achievement")]
    public class AchievementController : ControllerBase
    {
        private readonly IAchievementService _achievementService;
            
        public AchievementController(IAchievementService achievementService)
        {
            _achievementService = achievementService;
        }
        [HttpPost]
        public ActionResult Post([FromRoute] int boxerId, [FromBody] CreateAchievementDto dto)
        {
            var newAchievementId = _achievementService.Create(boxerId, dto);
            return Created($"api/boxer/{boxerId}/Achievement/{newAchievementId}",null);
            
        }
        [HttpGet("{achievementId}")]
        public ActionResult<AchievementDto> Get([FromRoute] int boxerId, [FromRoute] int achievementId)
        {
            AchievementDto achievement = _achievementService.GetById(boxerId, achievementId);
            return Ok(achievement);
        }

        [HttpGet]
        public ActionResult<List<AchievementDto>> GetAll([FromRoute] int boxerId)
        {
            List<AchievementDto> achievement = _achievementService.GetAll(boxerId);
            return Ok(achievement);
        }

        [HttpDelete]
        public ActionResult RemoveAll([FromRoute] int boxerId)
        {
            _achievementService.RemoveAllAchievements(boxerId);
            return NoContent();
        }

    }
}
