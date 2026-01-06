using Journify.core.Entities;

namespace Journify.service.Interfaces
{
    public interface IStepRepository
    {
        Task<IEnumerable<Step>> GetAllStepsAsync();
        Task<Step> AddStepAsync(Step step);
        Task<Step> GetStepById(Guid id);
    }
}
