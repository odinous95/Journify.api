using Journify.core.Entities;
using StepManagment.service.commands;
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



        public async Task CreateJourneyAsync(CreateJourneyCommand command)
        {
            DailyJourney journey = new();
            journey.JounreyName = command.JourneyName;
            await _journeyRepository.AddJourneyAsync(journey);
        }



        public async Task<DailyJourney> UpdateJourneyAsync(UpdateJourneyCommand command)
        {
            var existingJourney = await _journeyRepository.GetJourneyById(command.JourneyId);
            if (existingJourney == null)
            {

                throw new KeyNotFoundException($"Journey with ID {command.JourneyId} was not found.");
            }

            existingJourney.JounreyName = command.JourneyName;
            return await _journeyRepository.UpdateJourneyAsync(existingJourney);
        }






        public async Task<IEnumerable<DailyJourney>> GetAllJourneysAsync()
        {
            return await _journeyRepository.GetAllJourneysAsync();
        }
        public async Task<DailyJourney> GetJourneyByIdAsync(Guid id)
        {
            return await _journeyRepository.GetJourneyById(id);
        }

        public async Task<bool> DeleteJourneyAsync(Guid id)
        {
            return await _journeyRepository.DeleteJourneyAsync(id);
        }


    }
}
