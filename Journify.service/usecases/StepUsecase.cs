using Journify.core.Entities;
using Journify.service.Interfaces;

namespace Journify.service.usecases
{
    public class StepUsecase : IStepService
    {
        private readonly IStepRepository _stepRepository;
        public StepUsecase(IStepRepository stepRepository)
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
    }
}
