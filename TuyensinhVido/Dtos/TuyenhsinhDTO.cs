using System.ComponentModel.DataAnnotations;
using TuyensinhVido.Models;
namespace TuyensinhVido.Dtos
{
    public class TuyenhsinhDTO
    {
        public int Id { get; set; }
        [Required]
        public string? Hoten { get; set; }
        public string CMND { get; set; }
        public string? SDT { get; set; }
        public DateTime Ngaysinh { get; set; }
        public string? Hocba { get; set; }
        public string? Email { get; set; }
        public int? NganhId { get; set; }
        public Nganh? Nganh { get; set; }
    }
}
