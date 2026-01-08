using Journify.core.Entities;

namespace Journify.service.Interfaces
{
    public interface IDailyJourneyService
    {
        Task<DailyJourney> CreateJourneyAsync(DailyJourney journey);
        Task<IEnumerable<DailyJourney>> GetAllJourneysAsync();
        Task<DailyJourney> GetJourneyByIdAsync(Guid id);
    }
}
