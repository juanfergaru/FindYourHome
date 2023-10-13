using FindYourHome.API.Data;
using FindYourHome.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FindYourHome.API.Controllers
{
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("/api/payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly DataContext _context;

        public PaymentsController(DataContext context)
        {
            _context = context;
        }

        //Get por lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Payments.ToListAsync());
        }

        //Get por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var payment = await _context.Payments.FirstOrDefaultAsync(x => x.Id == id);
            if (payment is null)
            {
                return NotFound();
            }

            return Ok(payment);
        }

        // Post- Create
        [HttpPost]
        public async Task<ActionResult> Post(Payment payment)
        {
            _context.Add(payment);
            await _context.SaveChangesAsync();
            return Ok(payment);

        }

        // Put-- update
        [HttpPut]
        public async Task<ActionResult> Put(Payment payment)
        {

            _context.Update(payment);
            await _context.SaveChangesAsync();
            return Ok(payment);
        }

        // Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.Payments
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
