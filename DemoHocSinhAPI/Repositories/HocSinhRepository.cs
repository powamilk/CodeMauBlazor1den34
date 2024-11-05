using DemoHocSinhShare.Entities;
using DemoHocSinhShare;
using Microsoft.EntityFrameworkCore;

namespace DemoHocSinhAPI.Repositories
{
    public class HocSinhRepository : IHocSinhRepository
    {
        private readonly HocSinhDbContext _context;

        public HocSinhRepository(HocSinhDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HocSinh>> GetAllHocSinhs() => await _context.HocSinhs.ToListAsync();
        public async Task<HocSinh> GetHocSinhById(int id) => await _context.HocSinhs.FindAsync(id);
        public async Task AddHocSinh(HocSinh hocSinh) { _context.HocSinhs.Add(hocSinh); await _context.SaveChangesAsync(); }
        public async Task UpdateHocSinh(HocSinh hocSinh) { _context.HocSinhs.Update(hocSinh); await _context.SaveChangesAsync(); }
        public async Task DeleteHocSinh(int id) { var hocSinh = await GetHocSinhById(id); _context.HocSinhs.Remove(hocSinh); await _context.SaveChangesAsync(); }
    }
}
