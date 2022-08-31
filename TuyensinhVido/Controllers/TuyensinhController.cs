using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TuyensinhVido.Data;
using TuyensinhVido.Dtos;
using TuyensinhVido.Models;

namespace TuyensinhVido.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TuyensinhController : ControllerBase
    {
        private readonly TuyensinhDbContext _context;
        public TuyensinhController(TuyensinhDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<TuyenhsinhDTO>>> GetTuyensinh()
        {
            List<TuyenhsinhDTO> BvDTOs = new List<TuyenhsinhDTO>();
            var result = await (from tuyensinh in _context.tbl_Tuyensinh
                                join nganh in _context.tbl_Nganh on tuyensinh.NganhId equals nganh.id
                                select new
                                {
                                    Id = tuyensinh.Id,
                                    Hoten = tuyensinh.Hoten,
                                    CMND = tuyensinh.CMND,
                                    Ngaysinh = tuyensinh.Ngaysinh,
                                    Hocba = tuyensinh.Hocba,
                                    NganhId = tuyensinh.NganhId,
                                    Email = tuyensinh.Email,
                                    Nganh = tuyensinh.Nganh
                                }
                          ).ToListAsync();
            foreach (var item in result)
            {
                TuyenhsinhDTO bvdto = new TuyenhsinhDTO();
                bvdto.Id = item.Id;
                bvdto.Hoten = item.Hoten;
                bvdto.CMND = item.CMND;
                bvdto.Ngaysinh = item.Ngaysinh;
                bvdto.Hocba = item.Hocba;
                bvdto.Email = item.Email;
                bvdto.NganhId = item.NganhId;
                bvdto.Nganh = item.Nganh;

                BvDTOs.Add(bvdto);
            }
            if (BvDTOs != null)
                return Ok(BvDTOs);
            else
                return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult<List<Tuyensinh>>> CreateSinhVien(Tuyensinh tuyensinh)
        {
            _context.tbl_Tuyensinh.Add(tuyensinh);
            await _context.SaveChangesAsync();

            return Ok(tuyensinh);
        }
    }
}
