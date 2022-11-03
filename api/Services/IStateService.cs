using api.Dtos;
using api.Utility.Paging;

namespace api.Services
{
    public interface IStateService
    {
        ApiOkPagedResponse<IEnumerable<StateResWithCitiesCount>, MetaData>
            SearchStates(StateReqSearch dto);
        int Count();
        int Count(int countryId);
        StateRes FindById(int stateId);
        StateRes Create(StateReqEdit dto);
        StateRes Update(int stateId, StateReqEdit dto);
        void Delete(int stateId);
    }
}
