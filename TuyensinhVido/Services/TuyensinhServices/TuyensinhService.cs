using Microsoft.AspNetCore.Components;
using TuyensinhVido.Models;

namespace TuyensinhVido.Services.TuyensinhServices
{
    public class TuyensinhService : ITuyenhsinhService
    {
        public readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public List<Tuyensinh> TuyensinhServices { get; set; } = new List<Tuyensinh>();
        public TuyensinhService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
            _http.BaseAddress = new Uri(_navigationManager.BaseUri);
        }
        public Task CreateTuyensinh(Tuyensinh tuyensinh)
        {
            throw new NotImplementedException();
        }

        public async Task GetTuyensinhDetail()
        {
            var result = await _http.GetFromJsonAsync<List<Tuyensinh>>("api/tuyensinh");
            if (result != null)
            {
                TuyensinhServices = result;
            }
        }
    }
}
