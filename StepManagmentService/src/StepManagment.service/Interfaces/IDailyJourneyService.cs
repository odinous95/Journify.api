using Journify.core.Entities;
using StepManagment.service.commands;

namespace StepManagment.service.Interfaces
{
    public interface IDailyJourneyService
    {
        Task<Guid> CreateJourneyAsync(CreateJourneyCommand command);


        //-===-------------------------------------------
        Task<IEnumerable<DailyJourney>> GetAllJourneysAsync();
        Task<DailyJourney> GetJourneyByIdAsync(Guid id);
        Task<DailyJourney> UpdateJourneyAsync(DailyJourney journey);
        Task<bool> DeleteJourneyAsync(Guid id);
    }
}
