using CounterAPI.DBContext;
using CounterAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CounterAPI.Services
{
    public class CountRepository : ICountRepository
    {

        private readonly CountContext _countContext;

        public CountRepository(CountContext context)
        {
            _countContext = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Count> AddNumberAsync(Count newNumber)
        {
            await _countContext.Counts.AddAsync(newNumber);
            await _countContext.SaveChangesAsync();
            return newNumber;
        }

        public async Task DeleteNumberByIdAsync(int id)
        {
            var numberToDelete = await GetNumberByIdAsync(id);
            _countContext.Counts.Remove(numberToDelete);
            await _countContext.SaveChangesAsync();
        }

        public async Task<Count> GetNumberAsync()
        {
            return await _countContext.Counts.FirstOrDefaultAsync();
        }

        public async Task<Count> GetNumberByIdAsync(int id)
        {
            return await _countContext.Counts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Count>> GetNumberListAsync()
        {
            return await _countContext.Counts.OrderBy(x => x.Id).ToListAsync();
        }

        public Count UpdateNumber(Count updatedNumber)
        {           
            _countContext.Counts.Update(updatedNumber);
            _countContext.SaveChanges();
            return updatedNumber;
        }

    }
}
