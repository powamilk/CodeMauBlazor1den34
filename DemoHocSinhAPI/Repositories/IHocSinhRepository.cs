using DemoHocSinhShare.Entities;

namespace DemoHocSinhAPI.Repositories
{
    public interface IHocSinhRepository
    {
        Task<IEnumerable<HocSinh>> GetAllHocSinhs();
        Task<HocSinh> GetHocSinhById(int id);
        Task AddHocSinh(HocSinh hocSinh);
        Task UpdateHocSinh(HocSinh hocSinh);
        Task DeleteHocSinh(int id);
    }
}
