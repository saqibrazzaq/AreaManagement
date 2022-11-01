using api.Dtos;
using api.Entities;
using api.Exceptions;
using api.Repository;
using api.Utility.Paging;
using AutoMapper;

namespace api.Services
{
    public class CountryService : ICountryService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CountryService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public int Count()
        {
            return _repositoryManager.CountryRepository.FindAll(false)
                .Count();
        }

        public CountryRes Create(CountryReqEdit dto)
        {
            var entity = _mapper.Map<Country>(dto);
            _repositoryManager.CountryRepository.Create(entity);
            _repositoryManager.Save();
            return _mapper.Map<CountryRes>(entity);
        }

        public void Delete(int id)
        {
            var entity = FindCountryIfExists(id, true);
            _repositoryManager.CountryRepository.Delete(entity);
            _repositoryManager.Save();
        }

        private Country FindCountryIfExists(int id, bool trackChanges)
        {
            var entity = _repositoryManager.CountryRepository.FindByCondition(
                x => x.Id == id,
                trackChanges)
                .FirstOrDefault();
            if (entity == null) throw new NotFoundException("No country found with id " + id);

            return entity;
        }

        public CountryRes FindById(int id)
        {
            var entity = FindCountryIfExists(id, false);
            return _mapper.Map<CountryRes>(entity);
        }

        public ApiOkPagedResponse<IEnumerable<CountryRes>, MetaData> SearchCountries(CountryReqSearch dto)
        {
            var pagedEntities = _repositoryManager.CountryRepository.
                SearchCountries(dto, false);
            var dtos = _mapper.Map<IEnumerable<CountryRes>>(pagedEntities);
            return new ApiOkPagedResponse<IEnumerable<CountryRes>, MetaData>(dtos,
                pagedEntities.MetaData);
        }

        public CountryRes Update(int id, CountryReqEdit dto)
        {
            var entity = FindCountryIfExists(id, true);
            _mapper.Map(dto, entity);
            _repositoryManager.Save();
            return _mapper.Map<CountryRes>(entity);
        }
    }
}
