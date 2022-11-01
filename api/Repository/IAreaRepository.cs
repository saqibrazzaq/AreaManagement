using api.Dtos;
using api.Entities;
using api.Utility.Paging;

namespace api.Repository
{
    public interface IAreaRepository : IRepositoryBase<Area>
    {
        PagedList<Area> SearchAreas(AreaReqSearch dto, bool trackChanges);
    }
}
