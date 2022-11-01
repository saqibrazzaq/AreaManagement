using api.Data;
using api.Dtos;
using api.Entities;
using api.Utility.Paging;

namespace api.Repository
{
    public class CityRepository : RepositoryBase<City>, ICityRepository
    {
        public CityRepository(AppDbContext context) : base(context)
        {
        }

        public PagedList<City> SearchCities(CityReqSearch dto, bool trackChanges)
        {
            var entities = FindAll(trackChanges)
                .Search(dto)
                .Sort(dto.OrderBy)
                .Skip((dto.PageNumber - 1) * dto.PageSize)
                .Take(dto.PageSize)
                .ToList();
            var count = FindAll(trackChanges: false)
                .Search(dto)
                .Count();
            return new PagedList<City>(entities, count,
                dto.PageNumber, dto.PageSize);
        }
    }
}
