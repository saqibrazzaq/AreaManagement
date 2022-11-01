using api.Data;
using api.Dtos;
using api.Entities;
using api.Utility.Paging;

namespace api.Repository
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(AppDbContext context) : base(context)
        {
        }

        public PagedList<Country> SearchCountries(CountryReqSearch dto, bool trackChanges)
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
            return new PagedList<Country>(entities, count,
                dto.PageNumber, dto.PageSize);
        }
    }
}
