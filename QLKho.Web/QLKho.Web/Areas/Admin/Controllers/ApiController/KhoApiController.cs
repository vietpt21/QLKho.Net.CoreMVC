using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLKho.DataAccess.Repository.IRepository;
using QLKho.Models;

namespace QLKho.Web.Areas.Admin.Controllers.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoApiController : Controller
    {
       
        private readonly IUnitOfWork _unitOfWork;

        public KhoApiController(IUnitOfWork unitOfWork)
        {
      
           _unitOfWork = unitOfWork;
        }
        // GET: api/CongTyApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kho>>> Get()
        {
            try
            {
                var khos = await _unitOfWork.Kho.GetAll();
                return Ok(khos);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/CongTyApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kho>> GetById(int id)
        {
            try
            {
                var kho = await _unitOfWork.Kho.GetFirstOrDefault(x=>x.Id==id);

                if (kho == null)
                {
                    return NotFound(); // Return 404 Not Found if entity with specified ID is not found
                }

                return Ok(kho);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/CongTyApi
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Kho kho)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdKho = await _unitOfWork.Kho.Add(kho);
                return CreatedAtAction("GetKho", new { id = createdKho.Id }, createdKho);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/CongTyApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Kho updatedKho)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != updatedKho.Id)
            {
                return BadRequest("ID mismatch between route parameter and payload data.");
            }

            try
            {
                var existingKho = await _unitOfWork.Kho.GetFirstOrDefault(x => x.Id == id);

                if (existingKho == null)
                {
                    return NotFound(); // Return 404 Not Found if entity with specified ID is not found
                }

                // Update properties of existingCongTy with updatedCongTy
                existingKho.TenKho = updatedKho.TenKho;
                existingKho.NgayCapNhat = updatedKho.NgayCapNhat;
                existingKho.GhiChu = updatedKho.GhiChu;
                existingKho.NgayTao = updatedKho.NgayTao;
                existingKho.NguoiTao = updatedKho.NguoiTao;
                // Update other properties as needed
                await _unitOfWork.Kho.Update(existingKho);
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
                var existingKho = await _unitOfWork.Kho.GetFirstOrDefault(x=>x.Id==id);

                if (existingKho == null)
                {
                    return NotFound(); // Return 404 Not Found if entity with specified ID is not found
                }

                await _unitOfWork.Kho.Remove(existingKho);

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
