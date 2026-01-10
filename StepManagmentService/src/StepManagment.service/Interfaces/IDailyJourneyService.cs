using Journify.core.Entities;

namespace StepManagment.service.Interfaces
{
    public interface IDailyJourneyService
    {
        Task<DailyJourney> CreateJourneyAsync(DailyJourney journey);
        Task<IEnumerable<DailyJourney>> GetAllJourneysAsync();
        Task<DailyJourney> GetJourneyByIdAsync(Guid id);
    }
}
