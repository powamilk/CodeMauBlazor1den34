using DemoHocSinhShare.Entities;
using System.Net.Http.Json;

namespace DemoMauHocSinhBlazor.Service
{
    public class HocSinhService
    {
        private readonly HttpClient _httpClient;

        public HocSinhService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<HocSinh>> GetAllHocSinhs() =>
            await _httpClient.GetFromJsonAsync<IEnumerable<HocSinh>>("api/hocsinh");

        public async Task<HocSinh> GetHocSinhById(int id)
        {
            return await _httpClient.GetFromJsonAsync<HocSinh>($"api/hocsinh/{id}");
        }

        public async Task CreateHocSinh(HocSinh hocSinh) =>
            await _httpClient.PostAsJsonAsync("api/hocsinh", hocSinh);

        public async Task UpdateHocSinh(int id, HocSinh hocSinh) =>
            await _httpClient.PutAsJsonAsync($"api/hocsinh/{id}", hocSinh);

        public async Task DeleteHocSinh(int id) =>
            await _httpClient.DeleteAsync($"api/hocsinh/{id}");
    }
}
