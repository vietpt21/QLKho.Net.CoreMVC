using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLKho.DataAccess.Repository.IRepository;
using QLKho.Models;

namespace QLKho.Web.Areas.Admin.Controllers.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaCungCapApiController : Controller
    {
       
        private readonly IUnitOfWork _unitOfWork;

        public NhaCungCapApiController(IUnitOfWork unitOfWork)
        {
      
           _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhaCungCap>>> Get()
        {
            try
            {
                var nhacungcaps = await _unitOfWork.NhaCungCap.GetAll();
                return Ok(nhacungcaps);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/CongTyApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhaCungCap>> GetById(int id)
        {
            try
            {
                var nhacungcap = await _unitOfWork.NhaCungCap.GetFirstOrDefault(x => x.Id == id);

                if (nhacungcap == null)
                {
                    return NotFound(); // Return 404 Not Found if entity with specified ID is not found
                }

                return Ok(nhacungcap);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/CongTyApi
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NhaCungCap nhacungcap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdNhaCungCap = await _unitOfWork.NhaCungCap.Add(nhacungcap);
                return CreatedAtAction("GetCongTy", new { id = nhacungcap.Id }, createdNhaCungCap);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/CongTyApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] NhaCungCap updatedNhaCungCap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != updatedNhaCungCap.Id)
            {
                return BadRequest("ID mismatch between route parameter and payload data.");
            }

            try
            {
                var existingNhaCungCap = await _unitOfWork.NhaCungCap.GetFirstOrDefault(x => x.Id == id);

                if (existingNhaCungCap == null)
                {
                    return NotFound(); // Return 404 Not Found if entity with specified ID is not found
                }

                // Update properties of existingCongTy with updatedCongTy
                existingNhaCungCap.TenNhaCungCap = updatedNhaCungCap.TenNhaCungCap;
                existingNhaCungCap.HienThi = updatedNhaCungCap.HienThi;
                existingNhaCungCap.TenDayDu = updatedNhaCungCap.TenDayDu;
                existingNhaCungCap.LoaiNCC = updatedNhaCungCap.LoaiNCC;
                existingNhaCungCap.Logo = updatedNhaCungCap.Logo;
                existingNhaCungCap.NguoiDaiDien = updatedNhaCungCap.NguoiDaiDien;
                existingNhaCungCap.SDT = updatedNhaCungCap.SDT;
                existingNhaCungCap.TinhTrang = updatedNhaCungCap.TinhTrang;
                existingNhaCungCap.NVPhuTrach = updatedNhaCungCap.NVPhuTrach;
                existingNhaCungCap.GhiChu = updatedNhaCungCap.GhiChu;
                existingNhaCungCap.NgayTao = updatedNhaCungCap.NgayCapNhat;
                existingNhaCungCap.NgayCapNhat = updatedNhaCungCap.NgayCapNhat;
                // Update other properties as needed
                await _unitOfWork.NhaCungCap.Update(existingNhaCungCap);
                return NoContent(); // Return 204 No Content on successful update
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/CongTyApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existingNhaCungCap = await _unitOfWork.NhaCungCap.GetFirstOrDefault(x => x.Id == id);

                if (existingNhaCungCap == null)
                {
                    return NotFound(); // Return 404 Not Found if entity with specified ID is not found
                }

                await _unitOfWork.NhaCungCap.Remove(existingNhaCungCap);

                return NoContent(); // Return 204 No Content on successful deletion
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
