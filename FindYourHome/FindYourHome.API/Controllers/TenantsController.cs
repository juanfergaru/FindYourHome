using FindYourHome.API.Data;
using FindYourHome.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FindYourHome.API.Controllers
{
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("/api/tenants")]
    public class TenantsController : ControllerBase
    {
        private readonly DataContext _context;

        public TenantsController(DataContext context)
        {
            _context = context;
        }

        //Get por lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Tenants.ToListAsync());
        }

        //Get por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var tenant = await _context.Tenants.FirstOrDefaultAsync(x => x.Id == id);
            if (tenant is null)
            {
                return NotFound();
            }

            return Ok(tenant);
        }

        // Post- Create
        [HttpPost]
        public async Task<ActionResult> Post(Tenant tenant)
        {
            _context.Add(tenant);
            await _context.SaveChangesAsync();
            return Ok(tenant);

        }

        // Put-- update
        [HttpPut]
        public async Task<ActionResult> Put(Tenant tenant)
        {

            _context.Update(tenant);
            await _context.SaveChangesAsync();
            return Ok(tenant);
        }

        // Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.Tenants
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
