using api.Dtos;
using api.Entities;
using api.Utility.Paging;

namespace api.Repository
{
    public interface ICityRepository : IRepositoryBase<City>
    {
        PagedList<City> SearchCities(CityReqSearch dto, bool trackChanges);
    }
}
