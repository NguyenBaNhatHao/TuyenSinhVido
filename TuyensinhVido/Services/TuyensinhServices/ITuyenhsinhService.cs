using Microsoft.AspNetCore.Components;
using TuyensinhVido.Data;
using TuyensinhVido.Models;

namespace TuyensinhVido.Services.TuyensinhServices
{
    public interface ITuyenhsinhService
    {
        List<Tuyensinh> TuyensinhServices { get; set; }
        List<Nganh> NganhServices { get; set; }
        Task<string> UploadProductImage(MultipartFormDataContent content);

        Task GetTuyensinhDetail();
        Task GetNganhDetail();
        Task CreateTuyensinh(Tuyensinh tuyensinh);
    }
}
