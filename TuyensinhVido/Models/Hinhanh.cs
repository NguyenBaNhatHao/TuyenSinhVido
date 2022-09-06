using System.ComponentModel.DataAnnotations.Schema;

namespace TuyensinhVido.Models
{
    public class Hinhanh
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public string? ImageName { get; set; }
        public DateTime ImageTime { get; set; }
        public Tuyensinh ThiSinh { get; set; }

    }
}
