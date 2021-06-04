using Microsoft.EntityFrameworkCore;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBalansSaville.Data.DAL;

namespace MediaBalansSaville.Data.Repositories
{
    public class SliderRepository : Repository<Slider>, ISliderRepository
    {
        public SliderRepository(ApplicationDbContext context) : base(context) { }
        
        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }

        public async Task<IEnumerable<Slider>> GetAllSliders()
        {
            return await ApplicationDbContext.Sliders
                // .Include(a => a.SliderLangs)
                //     .ThenInclude(b => b.Lang)
                .ToListAsync();
        }

        public async Task<Slider> GetSliderById(int id)
        {
            return await ApplicationDbContext.Sliders
                // .Include(a => a.SliderLangs)
                //     .ThenInclude(b => b.Lang)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}