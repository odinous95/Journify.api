using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StepManagment.api.DTOS;
using StepManagment.service.commands;
using StepManagment.service.Interfaces;

namespace StepManagment.api.Controllers
{
    [ApiController]
    [Route("api/step")]
    public class StepController : ControllerBase
    {
        private readonly IStepService _stepService;

        public StepController(IStepService stepService)
        {
            _stepService = stepService;
        }
        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateStepAsync([FromBody] CreateStepDTO dto)
        {
            var command = new CreateStepCommand(
                dto.JourneyId,
                dto.Title,
                dto.Description
            );

            await _stepService.AddStepAsync(command);
            return Ok();
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStepAsync(
            Guid id,
            [FromBody] UpdateStepDTO dto)
        {
            var command = new UpdateStepCommand(
                id,
                dto.Title,
                dto.Description
            );

            await _stepService.UpdateStepAsync(command);
            return Ok();
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllStepsAsync()
        {
            var steps = await _stepService.GetAllStepsAsync();
            return Ok(steps);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStepById(Guid id)
        {
            var step = await _stepService.GetStepById(id);
            return Ok(step);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStepAsync(Guid id)
        {
            await _stepService.DeleteStepAsync(id);
            return NoContent();
        }
    }

}
