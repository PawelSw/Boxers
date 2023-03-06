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
            return Created($"api/{boxerId}/Achievement/{newAchievementId}",null);
            
        }

    }
}
