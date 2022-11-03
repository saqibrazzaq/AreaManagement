using api.Dtos;
using api.Entities;
using api.Utility.Paging;

namespace api.Repository
{
    public interface IStateRepository : IRepositoryBase<State>
    {
        PagedList<StateResWithCitiesCount> SearchStates(StateReqSearch dto, bool trackChanges);
    }
}
