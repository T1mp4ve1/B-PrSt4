using Microsoft.EntityFrameworkCore;
using Prigione.Data;
using Prigione.Models;

namespace Prigione.Services
{
    public class TrasgressoreService : ITrasgressoreService
    {
        private readonly PrigioneDbContext _service;
        public TrasgressoreService(PrigioneDbContext service)
        {
            _service = service;
        }

        //CREATE
        public async Task CreateAsync(TrasgressoreModel trasgressore)
        {
            _service.Trasgressori.Add(trasgressore);
            await _service.SaveChangesAsync();
        }

        //READ
        public async Task<List<TrasgressoreModel>> GetAllAsync()
        {
            return await _service.Trasgressori
                .OrderBy(t => t.Cognome)
                .ToListAsync();
        }

        //READ ID
        public async Task<TrasgressoreModel> GetByIdAsync(Guid id)
        {
            return await _service.Trasgressori.FindAsync(id);
        }

        //UPDATE
        public async Task UpdateAsync(TrasgressoreModel trasgressore)
        {
            _service.Trasgressori.Update(trasgressore);
            await _service.SaveChangesAsync();
        }

        //DELETE
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _service.Trasgressori.FindAsync(id);
            if (entity != null)
            {
                _service.Trasgressori.Remove(entity);
                await _service.SaveChangesAsync();
            }
        }
    }
}
