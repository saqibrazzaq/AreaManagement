using api.Data;
using api.Dtos;
using api.Entities;
using api.Utility.Paging;

namespace api.Repository
{
    public class StateRepository : RepositoryBase<State>, IStateRepository
    {
        public StateRepository(AppDbContext context) : base(context)
        {
        }

        public PagedList<State> SearchStates(StateReqSearch dto, bool trackChanges)
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
            return new PagedList<State>(entities, count,
                dto.PageNumber, dto.PageSize);
        }
    }
}
