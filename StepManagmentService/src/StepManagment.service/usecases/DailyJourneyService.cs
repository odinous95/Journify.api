using Journify.core.Entities;
using StepManagment.service.Interfaces;

namespace StepManagment.service.usecases
{
    public class DailyJourneyService : IDailyJourneyService
    {
        private readonly IDailyJourneyRepository _journeyRepository;
        public DailyJourneyService(IDailyJourneyRepository journeyRepository)
        {
            _journeyRepository = journeyRepository;
        }
        public async Task<DailyJourney> CreateJourneyAsync(DailyJourney journey)
        {
            return await _journeyRepository.AddJourneyAsync(journey);
        }
        public async Task<IEnumerable<DailyJourney>> GetAllJourneysAsync()
        {
            return await _journeyRepository.GetAllJourneysAsync();
        }
        public async Task<DailyJourney> GetJourneyByIdAsync(Guid id)
        {
            return await _journeyRepository.GetJourneyById(id);
        }
        public async Task<DailyJourney> UpdateJourneyAsync(DailyJourney journey)
        {
            return await _journeyRepository.UpdateJourneyAsync(journey);
        }
        public async Task<bool> DeleteJourneyAsync(Guid id)
        {
            return await _journeyRepository.DeleteJourneyAsync(id);
        }
    }
}
