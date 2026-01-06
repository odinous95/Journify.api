using Journify.core.Entities;

namespace Journify.service.Interfaces
{
    public interface IStepService
    {
        Task<IEnumerable<Step>> GetAllStepsAsync();
        Task<Step> AddStepAsync(Step step);
        Task<Step> GetStepById(Guid id);
        Task<Step> UpdateStepAsync(Step step);
        Task<bool> DeleteStepAsync(Guid id);
    }
}
