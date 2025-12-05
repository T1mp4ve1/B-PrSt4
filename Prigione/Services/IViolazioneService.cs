using Prigione.Models;

namespace Prigione.Services
{
    public interface IViolazioneService
    {
        Task CreateAsync(ViolazioneModel violazione); //CREATE
        Task<List<ViolazioneModel>> GetAllAsync(); //READ
        Task<ViolazioneModel> GetByIdAsync(int id); //BY ID
        Task UpdateAsync(ViolazioneModel violazione); //UPDATE
        Task DeleteAsync(int violazioneID); //DELETE
    }
}