using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TuyensinhVido.Data;
using TuyensinhVido.Dtos;
using TuyensinhVido.Models;
using System.IO;

namespace TuyensinhVido.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TuyensinhController : ControllerBase
    {
        private readonly TuyensinhDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public TuyensinhController(TuyensinhDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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
                                    SDT = tuyensinh.SDT,
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
                bvdto.SDT = item.SDT;
                bvdto.Ngaysinh = item.Ngaysinh;
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

        [HttpGet("nganh")]
        public async Task<ActionResult<List<Nganh>>> GetNganh()
        {
            List<NganhDTO> nganhDTOs = new List<NganhDTO>();
            var groupByLastNamesQuery = from nganh in _context.tbl_Nganh
                                        group nganh by new { nganh.ten, nganh.id } into nganhs
                                        select new NganhDTO() { id = nganhs.Key.id, ten = nganhs.Key.ten };

            foreach (var nameGroup in groupByLastNamesQuery)
            {
                NganhDTO nganhDTO = new NganhDTO();
                nganhDTO.id = nameGroup.id;
                nganhDTO.ten = nameGroup.ten;
                nganhDTOs.Add((nganhDTO));

            }
            return Ok(nganhDTOs);
        }

        [HttpPost]
        public async Task<ActionResult<List<TuyenhsinhDTO>>> CreateSinhVien(TuyenhsinhDTO tuyensinh)
        {
            List<Hinhanh> listhinhanhs = new List<Hinhanh>();
            tuyensinh.Hinhanh.ImageData.ForEach(item =>
            {
                Hinhanh hinhanh = new Hinhanh();
                hinhanh.Image = item;
                hinhanh.ImageName = "ten cc gi do";
                listhinhanhs.Add(hinhanh);
            });

            Tuyensinh content = new Tuyensinh();
            content.Hinhanh = listhinhanhs;
            content.Hoten = tuyensinh.Hoten;
            content.CMND = tuyensinh.CMND;
            content.SDT = tuyensinh.SDT;
            content.Ngaysinh = tuyensinh.Ngaysinh;
            content.Email = tuyensinh.Email;
            content.NganhId = tuyensinh.NganhId;
            content.Nganh = tuyensinh.Nganh;
            content.SDT = tuyensinh.SDT;

            _context.tbl_Tuyensinh.Add(content);
            await _context.SaveChangesAsync();
            return Ok(tuyensinh);
        }
        [HttpPost("upload")]
        public async Task<ActionResult> UploadHocba( ImageDTO ImageDto)
        {
            Hinhanh hinhanh = new Hinhanh();
            ImageDto.ImageData.ForEach(item =>
            {
                
            });
            
            //string filename = file.FileName;
            //string extention = Path.GetExtension(filename);
            //string[] allow = { ".jpg", ".png" };
            //if (!allow.Contains(extention.ToLower())){
            //    return BadRequest("Ivalid Image");
            //}
            //string filenamenew = $"{Guid.NewGuid()}{extention}";
            //string path = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot", "uploads", lastRow.Hoten+".png");
            //using (var filestream = new FileStream(path, FileMode.Create, FileAccess.Write))
            //{
            //    await file.CopyToAsync(filestream);
            //}
            return Ok(hinhanh);
        }

    }
}
