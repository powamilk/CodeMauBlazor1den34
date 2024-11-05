using DemoHocSinhAPI.Repositories;
using DemoHocSinhShare.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoHocSinhAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HocSinhController : ControllerBase
    {
        private readonly IHocSinhRepository _repository;

        public HocSinhController(IHocSinhRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HocSinh>>> GetHocSinhs() => Ok(await _repository.GetAllHocSinhs());

        [HttpGet("{id}")]
        public async Task<ActionResult<HocSinh>> GetHocSinh(int id) => Ok(await _repository.GetHocSinhById(id));

        [HttpPost]
        public async Task<IActionResult> CreateHocSinh(HocSinh hocSinh)
        {
            await _repository.AddHocSinh(hocSinh);
            return CreatedAtAction(nameof(GetHocSinh), new { id = hocSinh.Id }, hocSinh);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHocSinh(int id, HocSinh hocSinh)
        {
            if (id != hocSinh.Id) return BadRequest();
            await _repository.UpdateHocSinh(hocSinh);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHocSinh(int id)
        {
            await _repository.DeleteHocSinh(id);
            return NoContent();
        }
    }
}
