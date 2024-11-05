using DemoHocSinhAPI.Repositories;
using DemoHocSinhShare;
using DemoHocSinhShare.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoHocSinhAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HocSinhController : ControllerBase
    {
        private readonly IHocSinhRepository _repository;
        private readonly HocSinhDbContext _context;

        public HocSinhController(IHocSinhRepository repository, HocSinhDbContext context)
        {
            _repository = repository;
            _context = context;
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

        [HttpPut("sua-nhieu")]
        public async Task<IActionResult> UpdateNhieuHocSinh([FromBody] List<HocSinh> hocSinhs)
        {
            _context.HocSinhs.UpdateRange(hocSinhs);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("xoa-nhieu")]
        public async Task<IActionResult> DeleteNhieuHocSinh([FromBody] List<int> hocSinhIds)
        {
            var hocSinhDeletes = await _context.HocSinhs.Where(hs => hocSinhIds.Contains(hs.Id)).ToListAsync();
            _context.HocSinhs.RemoveRange(hocSinhDeletes);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("them-nhieu")]
        public async Task<IActionResult> AddNhieuHocSinh([FromBody] List<HocSinh> hocSinhs)
        {
            await _context.HocSinhs.AddRangeAsync(hocSinhs);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetHocSinh", new { id = hocSinhs.First().Id }, hocSinhs);
        }
    }
}
