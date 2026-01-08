using Journify.core.Entities;
using Journify.infrastructure.Data;
using Journify.service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Journify.infrastructure.Repository
{
    public class StepRepository : IStepRepository
    {
        private readonly AppDbContext _appDbcontext;
        public StepRepository(AppDbContext appDbContext)
        {
            _appDbcontext = appDbContext;
        }
        public async Task<Step> AddStepAsync(Step step)
        {
            _appDbcontext.Steps.Add(step);
            await _appDbcontext.SaveChangesAsync();
            return step;
        }
        public async Task<IEnumerable<Step>> GetAllStepsAsync()
        {
            return await _appDbcontext.Steps.ToListAsync();
        }
        public async Task<Step> GetStepById(Guid id)
        {
            return await _appDbcontext.Steps.FindAsync(id);
        }
        public async Task<Step> UpdateStepAsync(Step step)
        {
            _appDbcontext.Steps.Update(step);
            await _appDbcontext.SaveChangesAsync();
            return step;
        }
        public async Task<bool> DeleteStepAsync(Guid id)
        {
            var step = await _appDbcontext.Steps.FindAsync(id);
            if (step == null)
            {
                return false;
            }
            _appDbcontext.Steps.Remove(step);
            await _appDbcontext.SaveChangesAsync();
            return true;
        }
    }
}
