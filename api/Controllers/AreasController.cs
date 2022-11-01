using api.ActionFilters;
using api.Dtos;
using api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly IAreaService _areaService;

        public AreasController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] AreaReqSearch dto)
        {
            var res = _areaService.SearchAreas(dto);
            return Ok(res);
        }

        [HttpGet("{areaId}")]
        public IActionResult FindById(int areaId)
        {
            var res = _areaService.FindById(areaId);
            return Ok(res);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Create(AreaReqEdit dto)
        {
            var res = _areaService.Create(dto);
            return Ok(res);
        }

        [HttpPut("{areaId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Update(int areaid, AreaReqEdit dto)
        {
            var res = _areaService.Update(areaid, dto);
            return Ok(res);
        }

        [HttpDelete("{areaId}")]
        public IActionResult Delete(int areaId)
        {
            _areaService.Delete(areaId);
            return NoContent();
        }
    }
}
