using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Repositories
{
    public interface ISliderRepository : IRepository<Slider>
    {
        Task<IEnumerable<Slider>> GetAllSliders();
        Task<Slider> GetSliderById(int id);
    }
}