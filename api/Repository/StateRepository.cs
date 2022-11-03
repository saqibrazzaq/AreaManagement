using api.Data;
using api.Dtos;
using api.Entities;
using api.Utility.Paging;

namespace api.Repository
{
    public class StateRepository : RepositoryBase<State>, IStateRepository
    {
        private readonly AppDbContext _appDbContext;
        public StateRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }

        public PagedList<StateResWithCitiesCount> SearchStates(StateReqSearch dto, bool trackChanges)
        {
            var entities = SearchStatesWithCitiesCount()
                .Search(dto)
                .Sort(dto.OrderBy)
                .Skip((dto.PageNumber - 1) * dto.PageSize)
                .Take(dto.PageSize)
                .ToList();
            var count = SearchStatesWithCitiesCount()
                .Search(dto)
                .Count();
            return new PagedList<StateResWithCitiesCount>(entities, count,
                dto.PageNumber, dto.PageSize);
        }

        private IQueryable<StateResWithCitiesCount> SearchStatesWithCitiesCount()
        {
            var query = (
                from s in _appDbContext.Sates
                join c in _appDbContext.Cities on s.StateId equals c.StateId into grouping
                from p in grouping.DefaultIfEmpty()
                group p by new { s.StateId, s.Code, s.Name, s.CountryId } into g
                select new StateResWithCitiesCount()
                {
                    StateId = g.Key.StateId,
                    Code = g.Key.Code,
                    Name = g.Key.Name,
                    CountryId = g.Key.CountryId,
                    CitiesCount = g.Count(x => x != null)
                }
                );
            return query;
        }
    }
}
