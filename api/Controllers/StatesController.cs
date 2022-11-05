using api.ActionFilters;
using api.Dtos;
using api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IStateService _stateService;

        public StatesController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery]StateReqSearch dto)
        {
            var res = _stateService.SearchStates(dto);
            return Ok(res);
        }

        [HttpGet("searchStatesWithCitiesCount")]
        public IActionResult SearchStatesWithCitiesCount([FromQuery] StateReqSearch dto)
        {
            var res = _stateService.SearchStatesWithCitiesCount(dto);
            return Ok(res);
        }

        [HttpGet("count")]
        public IActionResult Count()
        {
            var res = _stateService.Count();
            return Ok(res);
        }

        [HttpGet("{stateId}")]
        public IActionResult FindById(int stateId)
        {
            var res = _stateService.FindById(stateId);
            return Ok(res);
        }

        [HttpGet("GetStateWithCountryAndCitiesCount/{stateId}")]
        public IActionResult GetStateWithCountryAndCitiesCount(int stateId)
        {
            var res = _stateService.GetStateWithCountryAndCitiesCount(stateId);
            return Ok(res);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Create(StateReqEdit dto)
        {
            var res = _stateService.Create(dto);
            return Ok(res);
        }

        [HttpPut("{stateId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Update(int stateId, StateReqEdit dto)
        {
            var res = _stateService.Update(stateId, dto);
            return Ok(res);
        }

        [HttpDelete("{stateId}")]
        public IActionResult Delete(int stateId)
        {
            _stateService.Delete(stateId);
            return NoContent();
        }
    }
}
