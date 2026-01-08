using Journify.core.Entities;
using Journify.service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Journify.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepController : ControllerBase
    {
        private readonly IStepService _stepService;
        public StepController(IStepService stepService)
        {
            _stepService = stepService;
        }
        [HttpGet]
        public async Task<ActionResult<Step>> GetAllStepsAsync()
        {
            var steps = await _stepService.GetAllStepsAsync();
            if (steps == null) return NotFound("No steps found.");
            return Ok(steps);
        }
        [HttpPost]
        public async Task<ActionResult<Step>> CreateStepAsync([FromBody] Step step)
        {
            if (step == null) return BadRequest("Step data is null.");
            var createdStep = await _stepService.AddStepAsync(step);
            return createdStep;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Step>> GetStepById(Guid id)
        {
            var step = await _stepService.GetStepById(id);
            if (step == null) return NotFound("Step not found.");
            return Ok(step);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Step>> UpdateStepAsync(Guid id, [FromBody] Step step)
        {
            if (step == null || id != step.Id) return BadRequest("Invalid step data.");
            var updatedStep = await _stepService.UpdateStepAsync(step);
            return Ok(updatedStep);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStepAsync(Guid id)
        {
            var result = await _stepService.DeleteStepAsync(id);
            if (!result) return NotFound("Step not found.");
            return NoContent();
        }
    }
}
