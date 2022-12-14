using api.Dtos;
using api.Entities;
using api.Utility.Paging;

namespace api.Repository
{
    public interface IStateRepository : IRepositoryBase<State>
    {
        PagedList<State> SearchStates(StateReqSearch dto, bool trackChanges);
        PagedList<StateResWithCitiesCount> SearchStatesWithCitiesCount(StateReqSearch dto, bool trackChanges);
        StateResWithCountryAndCitiesCount GetStateWithCountryAndCitiesCount(int stateId);
    }
}
