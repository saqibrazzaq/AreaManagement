using api.Dtos;
using api.Entities;
using api.Repository;
using AutoMapper;
using System.Text.Json;

namespace api.Services
{
    public class DataResetService : IDataResetService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DataResetService(IRepositoryManager repositoryManager,
            IMapper mapper,
            IWebHostEnvironment webHostEnvironment)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public void ResetAllData()
        {
            DeleteAllCountries();
            ImportAllCountries();
        }

        private void ImportAllCountries()
        {
            var countries = ReadCountriesFromJson();
            foreach(var country in countries)
            {
                _repositoryManager.CountryRepository.Create(country);
            }
            _repositoryManager.Save();
        }

        private IEnumerable<Country> ReadCountriesFromJson()
        {
            var rootPath = _webHostEnvironment.WebRootPath;
            var jsonFilePath = Path.Combine(rootPath, "data", "countries+states+cities.json");
            var jsonData = File.ReadAllText(jsonFilePath);
            var countriesImport = JsonSerializer.Deserialize<IEnumerable<CountryImport>>(jsonData);
            var countries = _mapper.Map<IEnumerable<Country>>(countriesImport);
            return countries;
        }

        private void DeleteAllCountries()
        {
            var entities = _repositoryManager.CountryRepository.FindAll(true);
            foreach (var entity in entities)
            {
                _repositoryManager.CountryRepository.Delete(entity);
            }
            _repositoryManager.Save();
        }
    }
}
