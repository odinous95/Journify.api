using Journify.core.Entities;
using Journify.service.Interfaces;

namespace Journify.service.usecases
{
    public class StepService : IStepService
    {
        private readonly IStepRepository _stepRepository;
        public StepService(IStepRepository stepRepository)
        {
            _stepRepository = stepRepository;
        }
        public async Task<Step> AddStepAsync(Step step)
        {
            return await _stepRepository.AddStepAsync(step);
        }

        public async Task<IEnumerable<Step>> GetAllStepsAsync()
        {
            return await _stepRepository.GetAllStepsAsync();
        }
        public async Task<Step> GetStepById(Guid id)
        {
            return await _stepRepository.GetStepById(id);
        }
    }
}
