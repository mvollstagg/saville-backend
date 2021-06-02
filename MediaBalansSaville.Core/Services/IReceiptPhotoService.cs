
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Services
{
    public interface IReceiptPhotoService
    {
        Task<ReceiptPhoto> CreateReceiptPhoto(ReceiptPhoto newReceiptPhoto);
        Task DeleteReceiptPhoto(ReceiptPhoto ReceiptPhoto);
    }
}