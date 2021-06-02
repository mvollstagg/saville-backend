using MediaBalansSaville.Core;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediaBalansSaville.Services
{
    public class SliderService : ISliderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SliderService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Slider> CreateSlider(Slider newSlider)
        {
            newSlider.UrlId = _unitOfWork.Sliders.TotalCount() + 1;
            await _unitOfWork.Sliders.AddAsync(newSlider);
            await _unitOfWork.CommitAsync();
            return newSlider;
        }

        public async Task DeleteSlider(Slider slider)
        {
            _unitOfWork.Sliders.Remove(slider);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Slider>> GetAllSliders()
        {
            return await _unitOfWork.Sliders.GetAllSliders();
        }

        public async Task<Slider> GetSliderById(int id)
        {
            return await _unitOfWork.Sliders.GetSliderById(id);
        }

        public async Task UpdateSlider(Slider sliderToBeUpdated, Slider slider)
        {
            sliderToBeUpdated.PhotoUrl = slider.PhotoUrl;
            sliderToBeUpdated.IsActive = slider.IsActive;
            sliderToBeUpdated.SliderLangs = slider.SliderLangs;

            await _unitOfWork.CommitAsync();
        }
    }
}