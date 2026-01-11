using Journify.core.Entities;

namespace StepManagment.service.Interfaces
{
    public interface IDailyJourneyRepository
    {
        Task<IEnumerable<DailyJourney>> GetAllJourneysAsync();
        Task<DailyJourney> AddJourneyAsync(DailyJourney journey);
        Task<DailyJourney> GetJourneyById(Guid id);
        Task<DailyJourney> UpdateJourneyAsync(DailyJourney journey);
        Task<bool> DeleteJourneyAsync(Guid id);
    }
}
