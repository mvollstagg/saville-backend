
using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Services
{
    public interface IExportationService
    {     
        Task<Exportation> GetExportations();
        Task<Exportation> CreateExportations(Exportation newExportation);
        Task UpdateExportations(Exportation ExportationToBeUpdated, Exportation Exportation);

        Task<IEnumerable<ExportationCountry>> GetAllCountries();  
        Task<ExportationCountry> GetCountryById(int id);
        Task<ExportationCountry> CreateCountry(ExportationCountry newCountry);
        Task UpdateCountry(ExportationCountry CountryToBeUpdated, ExportationCountry Country);
        Task DeleteCountry(ExportationCountry Country);
    }
}