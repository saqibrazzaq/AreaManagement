using api.Dtos;
using api.Utility.Paging;

namespace api.Services
{
    public interface ICountryService
    {
        ApiOkPagedResponse<IEnumerable<CountryRes>, MetaData>
            SearchCountries(CountryReqSearch dto);
        int Count();
        CountryRes FindById(int id);
        CountryRes Create(CountryReqEdit dto);
        CountryRes Update(int id, CountryReqEdit dto);
        void Delete(int id);
    }
}
