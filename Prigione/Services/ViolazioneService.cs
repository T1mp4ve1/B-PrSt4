using Microsoft.EntityFrameworkCore;
using Prigione.Data;
using Prigione.Models;

namespace Prigione.Services
{
    public class ViolazioneService : IViolazioneService
    {
        private readonly PrigioneDbContext _service;
        public ViolazioneService(PrigioneDbContext service)
        {
            _service = service;
        }

        //CREATE
        public async Task CreateAsync(ViolazioneModel violazione)
        {
            _service.Violazioni.Add(violazione);
            await _service.SaveChangesAsync();
        }

        //READ
        public async Task<List<ViolazioneModel>> GetAllAsync()
        {
            return await _service.Violazioni
                .OrderBy(v => v.ViolazioneID)
                .ToListAsync();
        }

        //READ: ID
        public async Task<ViolazioneModel> GetByIdAsync(int id)
        {
            return await _service.Violazioni.FindAsync(id);
        }

        //UPDATE
        public async Task UpdateAsync(ViolazioneModel violazione)
        {
            _service.Violazioni.Update(violazione);
            await _service.SaveChangesAsync();
        }

        //DELETE
        public async Task DeleteAsync(int id)
        {
            var entity = await _service.Violazioni.FindAsync(id);
            if (entity != null)
            {
                _service.Violazioni.Remove(entity);
                await _service.SaveChangesAsync();
            }
        }
    }
}
