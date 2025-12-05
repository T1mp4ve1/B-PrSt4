using Microsoft.EntityFrameworkCore;
using Prigione.Data;
using Prigione.Models;

namespace Prigione.Services
{
    public class VerbaleModelTestService : IVerbaleModelTestService
    {
        private readonly PrigioneDbContext _db;
        public VerbaleModelTestService(PrigioneDbContext db)
        {
            _db = db;
        }

        //CREATE
        public async Task CreateAsync(VerbaleModelTest verbal)
        {
            _db.VerbaliTest.Add(verbal);
            await _db.SaveChangesAsync();
        }

        //READ
        public async Task<List<VerbaleModelTest>> GetAllAsync()
        {
            return await _db.VerbaliTest
                .Include(v => v.Violazione)
                .Include(t => t.Trasgressore)
                .OrderBy(t => t.DecurtamentoPunti)
                .ToListAsync();
        }

        //READ ID
        public async Task<VerbaleModelTest> GetByIdAsync(Guid id)
        {
            return await _db.VerbaliTest.FindAsync(id);
        }

        //UPDATE
        public async Task UpdateAsync(VerbaleModelTest verbal)
        {
            _db.VerbaliTest.Update(verbal);
            await _db.SaveChangesAsync();
        }

        //DELETE
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _db.VerbaliTest.FindAsync(id);
            if (entity != null)
            {
                _db.VerbaliTest.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }
    }
}
