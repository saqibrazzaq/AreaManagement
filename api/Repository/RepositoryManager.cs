using api.Data;

namespace api.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext _context;
        private readonly Lazy<ICountryRepository> _countryRepository;
        private readonly Lazy<IStateRepository> _stateRepository;
        private readonly Lazy<ICityRepository> _cityRepository;
        private readonly Lazy<IAreaRepository> _areaRepository;
        public RepositoryManager(AppDbContext context)
        {
            _context = context;

            _countryRepository = new Lazy<ICountryRepository>(() =>
                new CountryRepository(context));
            _stateRepository = new Lazy<IStateRepository>(() =>
                new StateRepository(context));
            _cityRepository = new Lazy<ICityRepository>(() =>
                new CityRepository(context));
            _areaRepository = new Lazy<IAreaRepository>(() =>
                new AreaRepository(context));
        }

        public ICountryRepository CountryRepository => _countryRepository.Value;

        public IStateRepository StateRepository => _stateRepository.Value;

        public ICityRepository CityRepository => _cityRepository.Value;

        public IAreaRepository AreaRepository => _areaRepository.Value;
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
