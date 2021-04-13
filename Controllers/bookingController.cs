using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using negamed.Models;

namespace negamed.Controllers
{
    [Route("api/booking")]
    [ApiController]
    public class bookingController : ControllerBase
    {
        private readonly negamedContext _context;

        public bookingController(negamedContext context)
        {
            _context = context;
        }

        // GET: api/booking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<booking>>> Getbookings()
        {
            return await _context.bookings.ToListAsync();
        }

        // GET: api/booking/5
        [HttpGet("{id}")]
        public async Task<ActionResult<booking>> Getbooking(long id)
        {
            var booking = await _context.bookings.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        // PUT: api/booking/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putbooking(long id, booking booking)
        {
            if (id != booking.Id)
            {
                return BadRequest();
            }

            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!bookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/booking
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<booking>> Postbooking(booking booking)
        {
            _context.bookings.Add(booking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getbooking", new { id = booking.Id }, booking);
        }

        // DELETE: api/booking/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<booking>> Deletebooking(long id)
        {
            var booking = await _context.bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return booking;
        }

        private bool bookingExists(long id)
        {
            return _context.bookings.Any(e => e.Id == id);
        }
    }
}
