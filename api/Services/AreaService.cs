using api.Dtos;
using api.Entities;
using api.Exceptions;
using api.Repository;
using api.Utility.Paging;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class AreaService : IAreaService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public AreaService(IRepositoryManager repositoryManager, 
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public int Count()
        {
            return _repositoryManager.AreaRepository.FindAll(false)
                .Count();
        }

        public int Count(int cityId)
        {
            return _repositoryManager.AreaRepository.FindByCondition(
                x => x.CityId == cityId,
                false)
                .Count();
        }

        public AreaRes Create(AreaReqEdit dto)
        {
            var entity = _mapper.Map<Area>(dto);
            _repositoryManager.AreaRepository.Create(entity);
            _repositoryManager.Save();
            return _mapper.Map<AreaRes>(entity);
        }

        public void Delete(int areaId)
        {
            var entity = FindAreaIfExists(areaId, true);
            _repositoryManager.AreaRepository.Delete(entity);
            _repositoryManager.Save();
        }

        private Area FindAreaIfExists(int areaId, bool trackChanges)
        {
            var entity = _repositoryManager.AreaRepository.FindByCondition(
                x => x.AreaId == areaId,
                trackChanges,
                include: i => i.Include(x => x.City.State.Country))
                .FirstOrDefault();
            if (entity == null) throw new NotFoundException("No area found with id " + areaId);

            return entity;
        }

        public AreaRes FindById(int areaId)
        {
            var entity = FindAreaIfExists(areaId, false);
            return _mapper.Map<AreaRes>(entity);
        }

        public ApiOkPagedResponse<IEnumerable<AreaRes>, MetaData> SearchAreas(AreaReqSearch dto)
        {
            var pagedEntities = _repositoryManager.AreaRepository.
                SearchAreas(dto, false);
            var dtos = _mapper.Map<IEnumerable<AreaRes>>(pagedEntities);
            return new ApiOkPagedResponse<IEnumerable<AreaRes>, MetaData>(dtos,
                pagedEntities.MetaData);
        }

        public AreaRes Update(int areaId, AreaReqEdit dto)
        {
            var entity = FindAreaIfExists(areaId, true);
            _mapper.Map(dto, entity);
            _repositoryManager.Save();
            return _mapper.Map<AreaRes>(entity);
        }
    }
}
