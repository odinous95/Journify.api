using Journify.core.Entities;

namespace Journify.service.Interfaces
{
    public interface IStepRepository
    {
        Task<IEnumerable<Step>> GetAllStepsAsync();
        Task AddStepAsync(Step step);
    }
}
