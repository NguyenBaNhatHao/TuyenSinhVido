using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TuyensinhVido.Data;
using TuyensinhVido.Dtos;
using TuyensinhVido.Models;
using System.IO;
using System.Text;

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
            try
            {
                var jsonResult = new StringBuilder();
                var data = new StringBuilder();
                using (var cmd = _context.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandText = "GetSinhvien";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
                    var reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        jsonResult.Append("[]");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            data = jsonResult.Append(reader.GetValue(0).ToString());
                        }
                    }

                    return Ok(data.ToString().Replace("\\", ""));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
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
