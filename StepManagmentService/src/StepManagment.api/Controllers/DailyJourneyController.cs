using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StepManagment.api.DTOS;
using StepManagment.service.commands;
using StepManagment.service.Interfaces;

namespace StepManagment.api.Controllers
{
    [ApiController]
    [Route("api/dailyjourney")]
    public class DailyJourneyController : ControllerBase
    {
        private readonly IDailyJourneyService _dailyJourneyUsecase;

        public DailyJourneyController(IDailyJourneyService dailyJourneyUsecase)
        {
            _dailyJourneyUsecase = dailyJourneyUsecase;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateJourney([FromBody] CreateJourneyDTO dto)
        {
            var command = new CreateJourneyCommand(dto.userId, dto.journeyName);
            await _dailyJourneyUsecase.CreateJourneyAsync(command);
            return Ok();
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJourneyAsync([FromBody] UpdateJourneyDTO dto)
        {
            var command = new UpdateJourneyCommand(dto.JourneyId, dto.JourneyName);
            var updatedJourney = await _dailyJourneyUsecase.UpdateJourneyAsync(command);
            return Ok(updatedJourney);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJourneysAsync()
        {
            var journeys = await _dailyJourneyUsecase.GetAllJourneysAsync();
            return Ok(journeys); // Middleware handles empty/null if needed
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJourneyByIdAsync(Guid id)
        {
            var journey = await _dailyJourneyUsecase.GetJourneyByIdAsync(id);
            return Ok(journey); // Exception thrown if not found
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJourneyAsync(Guid id)
        {
            await _dailyJourneyUsecase.DeleteJourneyAsync(id); // Exception if not found
            return NoContent();
        }
    }

}
