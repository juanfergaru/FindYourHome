using FindYourHome.API.Data;
using FindYourHome.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FindYourHome.API.Controllers
{

    [ApiController]
    [Route("/api/Ownerships")]
    public class OwnershipsController : ControllerBase
    {
        private readonly DataContext _context;

        public OwnershipsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Ownerships.ToListAsync());
        }


        [AllowAnonymous]
        [HttpGet("combo")]
        public async Task<IActionResult> GetCombo()
        {
            return Ok(await _context.Ownerships.ToListAsync());
        }


        [HttpPost]
        public async Task<ActionResult> PostAsync(Ownership ownership)
        {
            try
            {
                // Verificar si Advisor existe
                if (ownership.AdvisorId != 0)
                {
                    var advisor = await _context.Advisors.FindAsync(ownership.AdvisorId);
                    if (advisor == null)
                    {
                        return NotFound("Advisor not found.");
                    }
                }

                // Verificar si Owner existe
                if (ownership.OwnerId != 0)
                {
                    var owner = await _context.Owners.FindAsync(ownership.OwnerId);
                    if (owner == null)
                    {
                        return NotFound("Owner not found.");
                    }
                }

                // Asegurarte de que al menos una relación esté establecida
                if (ownership.AdvisorId == 0 && ownership.OwnerId == 0)
                {
                    return BadRequest("Debe de ser propietario o asesor");
                }

                _context.Ownerships.Add(ownership);
                await _context.SaveChangesAsync();

                return Ok(ownership);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un inmueble con los mismos datos.");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var ownerships = await _context.Ownerships
                // .Include(x => x.Owner)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (ownerships == null)
            {
                return NotFound();
            }
            return Ok(ownerships);
        }



        [HttpPut]
        public async Task<ActionResult> PutAsync(Ownership ownership)
        {
            try
            {
                _context.Update(ownership);
                await _context.SaveChangesAsync();
                return Ok(ownership);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un inmueble con el mismo nombre.");
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
            var ownerships = await _context.Ownerships
            // .Include(x => x.Owner)
            .FirstOrDefaultAsync(x => x.Id == id);
            if (ownerships == null)
            {
                return NotFound();
            }
            _context.Remove(ownerships);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
