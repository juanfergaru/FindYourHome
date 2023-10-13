using FindYourHome.API.Data;
using FindYourHome.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FindYourHome.API.Controllers
{
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("/api/contracts")]
    public class ContractsController : ControllerBase
    {
        private readonly DataContext _context;

        public ContractsController(DataContext context)
        {
            _context = context;
        }

        //Get por lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Contracts.ToListAsync());
        }

        //Get por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var contract = await _context.Contracts.FirstOrDefaultAsync(x => x.Id == id);
            if (contract is null)
            {
                return NotFound();
            }

            return Ok(contract);
        }

        // Post- Create
        [HttpPost]
        public async Task<ActionResult> Post(Contract contract)
        {
            _context.Add(contract);
            await _context.SaveChangesAsync();
            return Ok(contract);

        }

        // Put-- update
        [HttpPut]
        public async Task<ActionResult> Put(Contract contract)
        {

            _context.Update(contract);
            await _context.SaveChangesAsync();
            return Ok(contract);
        }

        // Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.Contracts
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (filaafectada == 0)
            {

                return NotFound();

            }

            return NoContent();



        }


    }
}
