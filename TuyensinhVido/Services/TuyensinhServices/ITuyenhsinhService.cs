using Microsoft.AspNetCore.Components;
using TuyensinhVido.Data;
using TuyensinhVido.Models;
using TuyensinhVido.Dtos;

namespace TuyensinhVido.Services.TuyensinhServices
{
    public interface ITuyenhsinhService
    {
        List<Tuyensinh> TuyensinhServices { get; set; }
        List<Nganh> NganhServices { get; set; }
        Task UploadProductImage(List<ImageDTO> imageDTO);

        Task GetTuyensinhDetail();
        Task GetNganhDetail();
        Task CreateTuyensinh(TuyenhsinhDTO tuyensinh);
    }
}
