using api.Dtos;
using api.Entities;
using api.Utility.Paging;

namespace api.Repository
{
    public interface ICountryRepository : IRepositoryBase<Country>
    {
        PagedList<Country> SearchCountries(CountryReqSearch dto, bool trackChanges);
        PagedList<CountryResWithStatesCount> SearchCountriesWithStatesCount(CountryReqSearch dto, bool trackChanges);
        CountryResWithStatesCount GetCountryWithStatesCount(int countryId);
    }
}
