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

        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            var res = _stateService.FindById(id);
            return Ok(res);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Create(StateReqEdit dto)
        {
            var res = _stateService.Create(dto);
            return Ok(res);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Update(int id, StateReqEdit dto)
        {
            var res = _stateService.Update(id, dto);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _stateService.Delete(id);
            return NoContent();
        }
    }
}
