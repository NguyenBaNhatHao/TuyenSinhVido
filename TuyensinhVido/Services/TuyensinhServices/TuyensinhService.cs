using Microsoft.AspNetCore.Components;
using TuyensinhVido.Models;
using Tewr.Blazor.FileReader;
using TuyensinhVido.Dtos;

namespace TuyensinhVido.Services.TuyensinhServices
{
    public class TuyensinhService : ITuyenhsinhService
    {
        public readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public List<Tuyensinh> TuyensinhServices { get; set; } = new List<Tuyensinh>();
        public List<Nganh> NganhServices { get; set; } = new List<Nganh>();
        
        public TuyensinhService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
            _http.BaseAddress = new Uri(_navigationManager.BaseUri);
        }
        public async Task CreateTuyensinh(TuyenhsinhDTO tuyensinh)
        {

            var result = await _http.PostAsJsonAsync("api/tuyensinh", tuyensinh);
            await SetSinhvien(result);
        }
        private async Task SetSinhvien(HttpResponseMessage result)
        {
            Console.WriteLine(result.StatusCode);
            _navigationManager.NavigateTo("/tuyensinh");
        }
        public async Task GetTuyensinhDetail()
        {
            var result = await _http.GetFromJsonAsync<List<Tuyensinh>>("api/tuyensinh");
            if (result != null)
            {
                TuyensinhServices = result;
            }
        }

        public async Task GetNganhDetail()
        {
            var result = await _http.GetFromJsonAsync<List<Nganh>>("api/tuyensinh/nganh");
            if (result != null)
            {
                NganhServices = result;
            }
        }

        public async Task UploadProductImage(List<ImageDTO> imageDTO)
        {
            var postResult = await _http.PostAsJsonAsync("https://localhost:7058/api/tuyensinh/upload", imageDTO);
            //var postContent = await postResult.Content.ReadAsStringAsync();
            //if (!postResult.IsSuccessStatusCode)
            //{
            //    throw new ApplicationException(postContent);
            //}
            //else
            //{
            //    Console.WriteLine(name+DateTime.Now.ToString());

            //    //var imgUrl = Path.Combine("https://localhost:7058/", postContent);
            //    var imgUrl = Path.Combine(name+" "+ DateTime.Now.ToString()+postContent);
            //    return imgUrl;
            //}
            await SetSinhvien(postResult);
        }
    }
}
