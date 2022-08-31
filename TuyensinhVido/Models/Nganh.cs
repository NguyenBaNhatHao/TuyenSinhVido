using System.ComponentModel.DataAnnotations.Schema;

namespace TuyensinhVido.Models
{
    public class Nganh
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? id { get; set; }
        public string? ma { get; set; }
        public string? ten { get; set; }
        public string? KhoiThi { get; set; }
        public int? khoaId { get; set; }
        public int? heDaoTaoId { get; set; }
        public string? tenTA { get; set; }
        public string? KyHieu { get; set; }
    }
}
