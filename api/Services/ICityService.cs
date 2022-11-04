using api.Dtos;
using api.Utility.Paging;

namespace api.Services
{
    public interface ICityService
    {
        ApiOkPagedResponse<IEnumerable<CityRes>, MetaData>
            SearchCities(CityReqSearch dto);
        ApiOkPagedResponse<IEnumerable<CityResWithAreasCount>, MetaData>
            SearchCitiesWithAreaCount(CityReqSearch dto);
        int Count();
        int Count(int stateId);
        CityRes FindById(int cityId);
        CityResDetails GetCityDetails(int cityId);
        CityRes Create(CityReqEdit dto);
        CityRes Update(int cityId, CityReqEdit dto);
        void Delete(int cityId);
    }
}
