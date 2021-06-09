using System.Threading.Tasks;
using MediaBalansSaville.Core;
using MediaBalansSaville.Core.Repositories;
using MediaBalansSaville.Data.DAL;
using MediaBalansSaville.Data.Repositories;

namespace MediaBalansSaville.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private AboutSettingsRepository _aboutSettingsRepository;
        private AboutSettingsCertificateRepository _aboutSettingsCertificateRepository;
        private AboutSettingsItemRepository _aboutSettingsItemRepository;
        private ExportationRepository _exportationRepository;
        private ExportationCountryRepository _exportationCountryRepository;
        private FAQRepository _FAQRepository;
        private PomegranateSettingsRepository _pomegranateSettings;
        private LetterRepository _letterRepository;
        private UserRepository _userRepository;
        private UserRoleRepository _userRoleRepository;
        private RoleRepository _roleRepository;
        private LangRepository _langRepository;
        private ReceiptRepository _receiptRepository;
        private ReceiptPhotoRepository _receiptPhotoRepository;
        private SiteSettingsRepository _siteSettingsRepository;
        private CategoryRepository _categoryRepository;
        private CategoryLangRepository _categoryLangRepository;
        private SliderRepository _sliderRepository;
        private SeoRepository _seoRepository;
        private ProductRepository _productRepository;
        private ProductPhotoRepository _productPhotoRepository;
        

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IAboutSettingsRepository AboutSettings => _aboutSettingsRepository = _aboutSettingsRepository ?? new AboutSettingsRepository(_context);
        public IAboutSettingsItemRepository AboutSettingsItems => _aboutSettingsItemRepository = _aboutSettingsItemRepository ?? new AboutSettingsItemRepository(_context);
        public IAboutSettingsCertificateRepository AboutSettingsCertificates => _aboutSettingsCertificateRepository = _aboutSettingsCertificateRepository ?? new AboutSettingsCertificateRepository(_context);
        public IExportationRepository Exportations => _exportationRepository = _exportationRepository ?? new ExportationRepository(_context);
        public IExportationCountryRepository ExportationsCountries => _exportationCountryRepository = _exportationCountryRepository ?? new ExportationCountryRepository(_context);
        public IFAQRepository FAQs => _FAQRepository = _FAQRepository ?? new FAQRepository(_context);
        public IPomegranateRepository PomegranateSettings => _pomegranateSettings = _pomegranateSettings ?? new PomegranateSettingsRepository(_context);
        public ILetterRepository Letters => _letterRepository = _letterRepository ?? new LetterRepository(_context);
        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);
        public IReceiptRepository Receipts => _receiptRepository = _receiptRepository ?? new ReceiptRepository(_context);
        public IReceiptPhotoRepository ReceiptPhotos => _receiptPhotoRepository = _receiptPhotoRepository ?? new ReceiptPhotoRepository(_context);
        public IProductRepository Products=> _productRepository = _productRepository ?? new ProductRepository(_context);
        public IProductPhotoRepository ProductPhotos=> _productPhotoRepository = _productPhotoRepository ?? new ProductPhotoRepository(_context);
        public ISiteSettingsRepository SiteSettings => _siteSettingsRepository = _siteSettingsRepository ?? new SiteSettingsRepository(_context);
        public ISeoRepository Seos => _seoRepository = _seoRepository ?? new SeoRepository(_context);
        public ISliderRepository Sliders => _sliderRepository = _sliderRepository ?? new SliderRepository(_context);
        public IUserRoleRepository UserRoles => _userRoleRepository = _userRoleRepository ?? new UserRoleRepository(_context);
        public IRoleRepository Roles => _roleRepository = _roleRepository ?? new RoleRepository(_context);
        public ILangRepository Langs => _langRepository = _langRepository ?? new LangRepository(_context);
        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);
        public ICategoryLangRepository CategoryLangs => _categoryLangRepository = _categoryLangRepository ?? new CategoryLangRepository(_context);

        

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}