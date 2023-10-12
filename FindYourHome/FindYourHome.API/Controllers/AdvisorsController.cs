using FindYourHome.API.Data;
using FindYourHome.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FindYourHome.API.Controllers
{

    [ApiController]
    [Route("/api/Advisors")]
    public class AdvisorsController : ControllerBase
    {
        private readonly DataContext _context;

        public AdvisorsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Advisors
                .Include(x => x.Ownerships)
                .ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var state = await _context.Advisors
                .Include(x => x.Ownerships)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (state == null)
            {
                return NotFound();
            }

            return Ok(state);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Advisor advisor)
        {
            try
            {
                _context.Add(advisor);
                await _context.SaveChangesAsync();
                return Ok(advisor);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un Asesor con el mismo nombre.");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Advisor advisor)
        {
            try
            {
                _context.Update(advisor);
                await _context.SaveChangesAsync();
                return Ok(advisor);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un Asesor con el mismo nombre.");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var advisor = await _context.Advisors.FirstOrDefaultAsync(x => x.Id == id);
            if (advisor == null)
            {
                return NotFound();
            }

            _context.Remove(advisor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
