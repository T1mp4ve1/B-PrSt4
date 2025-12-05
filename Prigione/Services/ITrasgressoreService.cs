using Prigione.Models;

namespace Prigione.Services
{
    public interface ITrasgressoreService
    {
        Task CreateAsync(TrasgressoreModel trasgressore); //CREATE
        Task<List<TrasgressoreModel>> GetAllAsync(); //READ
        Task<TrasgressoreModel> GetByIdAsync(Guid id); //BY ID
        Task UpdateAsync(TrasgressoreModel trasgressore); //UPDATE
        Task DeleteAsync(Guid id); //DELETE
    }
}
