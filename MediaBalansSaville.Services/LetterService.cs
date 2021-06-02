using MediaBalansSaville.Core;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediaBalansSaville.Services
{
    public class LetterService : ILetterService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public LetterService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Letter> CreateLetter(Letter newLetter)
        {
            newLetter.SlugUrl = newLetter.FullName.Trim();
            newLetter.UrlId = _unitOfWork.Letters.TotalCount() + 1;
            await _unitOfWork.Letters.AddAsync(newLetter);
            await _unitOfWork.CommitAsync();
            return newLetter;
        }

        public async Task DeleteLetter(Letter letter)
        {
            _unitOfWork.Letters.Remove(letter);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Letter>> GetAllLetters()
        {
            return await _unitOfWork.Letters.GetAllAsync();
        }

        public async Task<Letter> GetLetterById(int id)
        {
            return await _unitOfWork.Letters.GetByIdAsync(id);
        }

        public async Task ToggleStatus(Letter letter)
        {
            letter.IsActive = !letter.IsActive;

            await _unitOfWork.CommitAsync();
        }
    }
}