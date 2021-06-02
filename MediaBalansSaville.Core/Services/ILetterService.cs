using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Services
{
    public interface ILetterService
    {
        Task<IEnumerable<Letter>> GetAllLetters();     
        Task<Letter> GetLetterById(int id);
        Task<Letter> CreateLetter(Letter newLetter);
        Task DeleteLetter(Letter letter);
        Task ToggleStatus(Letter letter);
    }
}