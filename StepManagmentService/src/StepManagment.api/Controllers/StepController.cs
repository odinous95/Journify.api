using Journify.core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StepManagment.api.DTOS;
using StepManagment.service.commands;
using StepManagment.service.Interfaces;

namespace StepManagment.api.Controllers
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




        [Authorize]
        [HttpGet]
        public async Task<ActionResult<Step>> GetAllStepsAsync()
        {
            var steps = await _stepService.GetAllStepsAsync();
            if (steps == null) return NotFound("No steps found.");
            return Ok(steps);
        }




        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Step>> CreateStepAsync([FromBody] CreateStepDTO dto)
        {
            if (dto == null) return BadRequest("Data is null.");
            var command = new CreateStepCommand(dto.Title, dto.Description);
            await _stepService.AddStepAsync(command);
            return Ok();
        }


        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Step>> GetStepById(Guid id)
        {
            var step = await _stepService.GetStepById(id);
            if (step == null) return NotFound("Step not found.");
            return Ok(step);
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Step>> UpdateStepAsync(Guid id, [FromBody] Step step)
        {
            if (step == null || id != step.Id) return BadRequest("Invalid step data.");
            var updatedStep = await _stepService.UpdateStepAsync(step);
            return Ok(updatedStep);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStepAsync(Guid id)
        {
            var result = await _stepService.DeleteStepAsync(id);
            if (!result) return NotFound("Step not found.");
            return NoContent();
        }
    }
}
