using Journify.core.Entities;
using Journify.service.Interfaces;

namespace Journify.infrastructure
{
    public class JounifyInMemoryDb : IStepRepository
    {
        private readonly List<Step> _steps = new List<Step>();
        public Task<Step> AddStepAsync(Step step)
        {
            if (step == null)
            {
                throw new ArgumentNullException(nameof(step));
            }

            if (_steps.Any(s => s.Id == step.Id))
            {
                throw new InvalidOperationException("Step with the same Id already exists.");
            }

            _steps.Add(step);
            return Task.FromResult(step);
        }

        public Task<IEnumerable<Step>> GetAllStepsAsync()
        {
            return Task.FromResult(_steps.AsEnumerable());
        }
    }
}
