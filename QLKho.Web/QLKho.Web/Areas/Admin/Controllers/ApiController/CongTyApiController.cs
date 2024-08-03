using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLKho.DataAccess.Repository.IRepository;
using QLKho.Models;

namespace QLKho.Web.Areas.Admin.Controllers.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CongTyApiController : Controller
    {
       
        private readonly IUnitOfWork _unitOfWork;

        public CongTyApiController(IUnitOfWork unitOfWork)
        {
      
           _unitOfWork = unitOfWork;
        }
        // GET: api/CongTyApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CongTy>>> Get()
        {
            try
            {
                var congTies = await _unitOfWork.CongTy.GetAll();
                return Ok(congTies);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/CongTyApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CongTy>> GetById(int id)
        {
            try
            {
                var congTy = await _unitOfWork.CongTy.GetFirstOrDefault(x=>x.Id==id);

                if (congTy == null)
                {
                    return NotFound(); // Return 404 Not Found if entity with specified ID is not found
                }

                return Ok(congTy);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/CongTyApi
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CongTy congTy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdCongTy = await _unitOfWork.CongTy.Add(congTy);
                return CreatedAtAction("GetCongTy", new { id = createdCongTy.Id }, createdCongTy);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/CongTyApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CongTy updatedCongTy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != updatedCongTy.Id)
            {
                return BadRequest("ID mismatch between route parameter and payload data.");
            }

            try
            {
                var existingCongTy = await _unitOfWork.CongTy.GetFirstOrDefault(x => x.Id == id);

                if (existingCongTy == null)
                {
                    return NotFound(); // Return 404 Not Found if entity with specified ID is not found
                }

                // Update properties of existingCongTy with updatedCongTy
                existingCongTy.TenCTy = updatedCongTy.TenCTy;
                existingCongTy.TenDayDu = updatedCongTy.TenDayDu;
                existingCongTy.NguoiDaiDien = updatedCongTy.NguoiDaiDien;
                existingCongTy.DiaChi = updatedCongTy.DiaChi;
                existingCongTy.SDT = updatedCongTy.SDT;
                existingCongTy.Email = updatedCongTy.Email;
                existingCongTy.Wensite = updatedCongTy.Wensite;
                existingCongTy.NgayTao = updatedCongTy.NgayTao;
                // Update other properties as needed

                await _unitOfWork.CongTy.Update(existingCongTy);

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
                var existingCongTy = await _unitOfWork.CongTy.GetFirstOrDefault(x=>x.Id==id);

                if (existingCongTy == null)
                {
                    return NotFound(); // Return 404 Not Found if entity with specified ID is not found
                }

                await _unitOfWork.CongTy.Remove(existingCongTy);

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
