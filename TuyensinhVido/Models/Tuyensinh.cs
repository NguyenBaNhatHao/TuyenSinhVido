using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace TuyensinhVido.Models
{
    public class Tuyensinh
    {
        [Key]
        [Required]
        public int? Id { get; set; }
        public string? Hoten { get; set; }
        public string? CMND { get; set; }
        public DateTime Ngaysinh { get; set; }
        public string? Hocba { get; set; }
        public int? NganhId { get; set; }
        public string? Email { get; set; }
        public virtual Nganh? Nganh { get; set; }
    }
}
