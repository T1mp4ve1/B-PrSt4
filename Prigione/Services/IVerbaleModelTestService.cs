using Prigione.Models;

namespace Prigione.Services
{
    public interface IVerbaleModelTestService
    {
        Task CreateAsync(VerbaleModelTest verbale); //CREATE
        Task<List<VerbaleModelTest>> GetAllAsync(); //READ
        Task<VerbaleModelTest> GetByIdAsync(Guid id); //BY ID
        Task UpdateAsync(VerbaleModelTest verbale); //UPDATE
        Task DeleteAsync(Guid id); //DELETE
    }
}
