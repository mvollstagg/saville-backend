using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Services
{
    public interface ISliderService
    {
        Task<IEnumerable<Slider>> GetAllSliders();        
        Task<Slider> GetSliderById(int id);
        Task<Slider> CreateSlider(Slider newSlider);
        Task UpdateSlider(Slider sliderToBeUpdated, Slider slider);
        Task DeleteSlider(Slider slider);
    }
}