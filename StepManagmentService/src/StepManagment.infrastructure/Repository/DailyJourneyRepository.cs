using Journify.core.Entities;
using Microsoft.EntityFrameworkCore;
using StepManagment.infrastructure.Data;
using StepManagment.service.Interfaces;

namespace StepManagment.infrastructure.Repository
{

    public class DailyJourneyRepository : IDailyJourneyRepository
    {
        private readonly AppDbContext _appDbcontext;
        public DailyJourneyRepository(AppDbContext appDbContext)
        {
            _appDbcontext = appDbContext;
        }
        public async Task<DailyJourney> AddJourneyAsync(DailyJourney journey)
        {
            _appDbcontext.DailyJournies.Add(journey);
            await _appDbcontext.SaveChangesAsync();
            return journey;
        }

        public async Task<IEnumerable<DailyJourney>> GetAllJourneysAsync()
        {
            return await _appDbcontext.DailyJournies.ToListAsync();
        }

        public async Task<DailyJourney> GetJourneyById(Guid id)
        {
            return await _appDbcontext.DailyJournies.FindAsync(id);

        }
    }
}
