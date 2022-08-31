using TuyensinhVido.Data;
using TuyensinhVido.Models;
namespace TuyensinhVido.Services.TuyensinhServices
{
    public interface ITuyenhsinhService
    {
        List<Tuyensinh> TuyensinhServices { get; set; }
        Task GetTuyensinhDetail();
        Task CreateTuyensinh(Tuyensinh tuyensinh);
    }
}
