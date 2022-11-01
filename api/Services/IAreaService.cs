using api.Dtos;
using api.Utility.Paging;

namespace api.Services
{
    public interface IAreaService
    {
        ApiOkPagedResponse<IEnumerable<AreaRes>, MetaData>
            SearchAreas(AreaReqSearch dto);
        int Count();
        int Count(int cityId);
        AreaRes FindById(int areaId);
        AreaRes Create(AreaReqEdit dto);
        AreaRes Update(int areaId, AreaReqEdit dto);
        void Delete(int areaId);
    }
}
