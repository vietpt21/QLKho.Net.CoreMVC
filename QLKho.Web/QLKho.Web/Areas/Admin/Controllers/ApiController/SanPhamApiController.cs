using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLKho.DataAccess.Repository.IRepository;
using QLKho.Models;
using static System.Net.Mime.MediaTypeNames;

namespace QLKho.Web.Areas.Admin.Controllers.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamApiController : Controller
    {
       
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ILogger<SanPhamApiController> _logger;
        public SanPhamApiController(IUnitOfWork unitOfWork, ILogger<SanPhamApiController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        // GET: api/CongTyApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SanPham>>> Get()
        {
            try
            {
                var sanphams = await _unitOfWork.SanPham.GetAll();
                return Ok(sanphams);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/CongTyApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SanPham>> GetById(int id)
        {
            try
            {
                var sanPham = await _unitOfWork.SanPham.GetFirstOrDefault(x=>x.Id==id);

                if (sanPham == null)
                {
                    return NotFound(); // Return 404 Not Found if entity with specified ID is not found
                }

                return Ok(sanPham);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<SanPham>> Post([FromForm] SanPham sanPham, IFormFile? hinhAnh)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { errors });
            }

            try
            {
                if (hinhAnh != null && hinhAnh.Length > 0)
                {
                    var fileName = Path.GetFileName(hinhAnh.FileName);
                    var filePath = Path.Combine("wwwroot/Images", fileName);

                    var directoryPath = Path.GetDirectoryName(filePath);
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await hinhAnh.CopyToAsync(stream);
                    }
                    sanPham.HinhAnh = fileName;
                }
                /*_unitOfWork.SanPham.Add(sanPham);*/

                SanPham spnew = await _unitOfWork.SanPham.Add(sanPham);
                return CreatedAtAction(nameof(GetById), new { id = spnew.Id }, spnew);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing request");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SanPham>> Put(int id, [FromForm] SanPham sanPham, IFormFile? hinhAnh)
        {
           
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { errors });
            }

            try
            {
               
                // Fetch the existing product from the database
                var existingSanPham = await _unitOfWork.SanPham.GetFirstOrDefault(x=>x.Id == id);
                if (existingSanPham == null)
                {
                    return NotFound($"Product with ID {id} not found.");
                }

                // Update product details
                existingSanPham.TenSanPham = sanPham.TenSanPham;
                existingSanPham.HienThi = sanPham.HienThi;
                existingSanPham.NhomSanPham = sanPham.NhomSanPham;
                existingSanPham.DiaChi = sanPham.DiaChi;
                existingSanPham.ThongTin = sanPham.ThongTin;
                existingSanPham.HanSuDung = sanPham.HanSuDung;
                existingSanPham.QuyCach = sanPham.QuyCach;
                existingSanPham.Dvt = sanPham.Dvt;
                existingSanPham.GiaNhap = sanPham.GiaNhap;
                existingSanPham.SLToiThieu = sanPham.SLToiThieu;
                existingSanPham.SLToiDa = sanPham.SLToiDa;
                existingSanPham.SLNhap = sanPham.SLNhap;
                existingSanPham.SLXuat = sanPham.SLXuat;
                existingSanPham.SLTon = sanPham.SLTon;
                existingSanPham.TrangThai = sanPham.TrangThai;
                existingSanPham.Ghichu = sanPham.Ghichu;
                existingSanPham.NgayTao = sanPham.NgayTao;
                existingSanPham.NgayCapNhat = sanPham.NgayCapNhat;
                existingSanPham.NguoiTao = sanPham.NguoiTao;
                existingSanPham.HinhAnh = null;
                // Handle image update if a new image is provided
                if (hinhAnh != null && hinhAnh.Length > 0)
                {
                    var fileName = Path.GetFileName(hinhAnh.FileName);
                    var filePath = Path.Combine("wwwroot/Images", fileName);

                    var directoryPath = Path.GetDirectoryName(filePath);
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await hinhAnh.CopyToAsync(stream);
                    }

                    // Optionally, delete the old image if it exists
                    if (!string.IsNullOrEmpty(sanPham.HinhAnh))
                    {
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                    }


                    existingSanPham.HinhAnh = fileName;
                }
             

                // Save the updated product
                await _unitOfWork.SanPham.Update(existingSanPham);
                return NoContent(); // Return 204 No Content on successful update
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing request");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                // Fetch the product to be deleted
                var sanPham = await _unitOfWork.SanPham.GetFirstOrDefault(x=>x.Id== id);
                if (sanPham == null)
                {
                    return NotFound($"Product with ID {id} not found.");
                }

                // Remove the associated image if it exists
                if (!string.IsNullOrEmpty(sanPham.HinhAnh))
                {
                    var filePath = Path.Combine("wwwroot/Images", sanPham.HinhAnh);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }

                // Delete the product from the database
                _unitOfWork.SanPham.Remove(sanPham);
              

                return NoContent(); // Successfully deleted
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing request");
                return StatusCode(500, "Internal server error.");
            }
        }

    }
}
