using TuyensinhVido.Models;
using Microsoft.EntityFrameworkCore;
namespace TuyensinhVido.Data
{
    public class TuyensinhDbContext : DbContext
    {
        public TuyensinhDbContext(DbContextOptions<TuyensinhDbContext> options)
            : base(options)
        {
        }
        public DbSet<Tuyensinh> tbl_Tuyensinh { get; set; }
        public DbSet<Nganh> tbl_Nganh { get; set; }
    }
}
