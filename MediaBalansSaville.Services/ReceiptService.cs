using MediaBalansSaville.Core;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediaBalansSaville.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public ReceiptService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Receipt> CreateReceipt(Receipt newReceipt)
        {
            newReceipt.UrlId = _unitOfWork.Receipts.TotalCount() + 1;
            await _unitOfWork.ReceiptPhotos.AddRangeAsync(newReceipt.ReceiptPhotos);
            await _unitOfWork.Receipts.AddAsync(newReceipt);
            await _unitOfWork.CommitAsync();
            return newReceipt;
        }

        public async Task DeleteReceipt(Receipt receipt)
        {
            _unitOfWork.Receipts.Remove(receipt);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Receipt>> GetAllReceipts()
        {
            return await _unitOfWork.Receipts.GetAllReceipts();
        }

        public async Task<Receipt> GetReceiptById(int id)
        {
            return await _unitOfWork.Receipts.GetReceiptById(id);
        }

        public async Task<Receipt> GetReceiptBySlugUrlAndUrlId(string slugurl, int urlid)
        {
            return await _unitOfWork.Receipts.GetReceiptBySlugUrlAndUrlId(slugurl, urlid);  
        }

        public async Task UpdateReceipt(Receipt receiptToBeUpdated, Receipt receipt)
        {
            receiptToBeUpdated.ReceiptLangs = receipt.ReceiptLangs;
            receiptToBeUpdated.ReceiptPhotos = receipt.ReceiptPhotos;
            receiptToBeUpdated.ReceiptSeo = receipt.ReceiptSeo;
            receiptToBeUpdated.SlugUrl = receipt.SlugUrl;
            receiptToBeUpdated.IsActive = receipt.IsActive;

            await _unitOfWork.CommitAsync();
        }
    }
}