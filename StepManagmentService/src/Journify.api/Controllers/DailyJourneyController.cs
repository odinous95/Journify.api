using Journify.core.Entities;
using Journify.service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Journify.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyJourneyController : ControllerBase
    {
        private readonly IDailyJourneyService _dailyJourneyUsecase;
        public DailyJourneyController(IDailyJourneyService dailyJourneyUsecase)
        {
            _dailyJourneyUsecase = dailyJourneyUsecase;
        }
        [HttpPost]
        public async Task<ActionResult<DailyJourney>> CreateJourney([FromBody] DailyJourney journey)
        {
            if (journey == null) return BadRequest("Step data is null.");
            var createdJourney = await _dailyJourneyUsecase.CreateJourneyAsync(journey);
            return createdJourney;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyJourney>>> GetAllJourneysAsync()
        {
            var journeys = await _dailyJourneyUsecase.GetAllJourneysAsync();
            if (journeys == null) return NotFound("No journeys found.");
            return Ok(journeys);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DailyJourney>> GetJourneyByIdAsync(Guid id)
        {
            var journey = await _dailyJourneyUsecase.GetJourneyByIdAsync(id);
            if (journey == null) return NotFound("Journey not found.");
            return Ok(journey);
        }
    }
}
