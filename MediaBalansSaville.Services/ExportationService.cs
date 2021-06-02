using MediaBalansSaville.Core;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Services;
using System.Threading.Tasks;

namespace MediaBalansSaville.Services
{
    public class ExportationService : IExportationService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public ExportationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<ExportationCountry> CreateCountry(ExportationCountry newCountry)
        {
            await _unitOfWork.ExportationsCountries.AddAsync(newCountry);
            await _unitOfWork.CommitAsync();
            return newCountry;
        }

        public async Task<Exportation> CreateExportations(Exportation newExportation)
        {
            await _unitOfWork.Exportations.AddAsync(newExportation);
            await _unitOfWork.CommitAsync();
            return newExportation;
        }

        public async Task DeleteCountry(ExportationCountry Country)
        {
            _unitOfWork.ExportationsCountries.Remove(Country);
            await _unitOfWork.CommitAsync();
        }

        public async Task<ExportationCountry> GetCountryById(int id)
        {
            return await _unitOfWork.ExportationsCountries.GetByIdAsync(id);
        }

        public async Task<Exportation> GetExportations()
        {
            return await _unitOfWork.Exportations.GetExportations();
        }

        public async Task UpdateCountry(ExportationCountry CountryToBeUpdated, ExportationCountry Country)
        {
            CountryToBeUpdated = Country;
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateExportations(Exportation ExportationToBeUpdated, Exportation Exportation)
        {
            ExportationToBeUpdated = Exportation;
            ExportationToBeUpdated.ExportationCountries = Exportation.ExportationCountries;
            ExportationToBeUpdated.ExportationLangs = Exportation.ExportationLangs;

            await _unitOfWork.CommitAsync();
        }
    }
}