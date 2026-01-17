using Journify.core.Entities;
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





        //[Authorize]
        [HttpPost()]
        [Route("create")]
        public async Task<ActionResult<CreateJourneyDTO>> CreateJourney([FromBody] CreateJourneyDTO request)
        {
            if (request == null) return BadRequest("Data is null.");
            var command = new CreateJourneyCommand(request.userId, request.journeyName);
            var result = await _dailyJourneyUsecase.CreateJourneyAsync(command);
            return Ok(result);
        }




        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyJourney>>> GetAllJourneysAsync()
        {
            var journeys = await _dailyJourneyUsecase.GetAllJourneysAsync();
            if (journeys == null) return NotFound("No journeys found.");
            return Ok(journeys);
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<DailyJourney>> GetJourneyByIdAsync(Guid id)
        {
            var journey = await _dailyJourneyUsecase.GetJourneyByIdAsync(id);
            if (journey == null) return NotFound("Journey not found.");
            return Ok(journey);
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<DailyJourney>> UpdateJourneyAsync(Guid id, [FromBody] DailyJourney journey)
        {
            if (journey == null || id != journey.Id) return BadRequest("Invalid journey data.");
            var updatedJourney = await _dailyJourneyUsecase.UpdateJourneyAsync(journey);
            return Ok(updatedJourney);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteJourneyAsync(Guid id)
        {
            var result = await _dailyJourneyUsecase.DeleteJourneyAsync(id);
            if (!result) return NotFound("Journey not found.");
            return NoContent();
        }
    }
}
