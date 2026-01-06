using Journify.core.Entities;

namespace Journify.service.Interfaces
{
    public interface IDailyJourneyRepository
    {
        Task<IEnumerable<DailyJourney>> GetAllJourneysAsync();
        Task<DailyJourney> AddJourneyAsync(DailyJourney journey);
        Task<DailyJourney> GetJourneyById(Guid id);
    }
}
