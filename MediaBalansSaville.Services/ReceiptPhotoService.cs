using MediaBalansSaville.Core;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Services;
using System.Threading.Tasks;

namespace MediaBalansSaville.Services
{
    public class ReceiptPhotoService : IReceiptPhotoService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public ReceiptPhotoService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<ReceiptPhoto> CreateReceiptPhoto(ReceiptPhoto newReceiptPhoto)
        {
            await _unitOfWork.ReceiptPhotos.AddAsync(newReceiptPhoto);
            await _unitOfWork.CommitAsync();
            return newReceiptPhoto;
        }

        public async Task DeleteReceiptPhoto(ReceiptPhoto ReceiptPhoto)
        {
            _unitOfWork.ReceiptPhotos.Remove(ReceiptPhoto);

            await _unitOfWork.CommitAsync();
        }
    }
}