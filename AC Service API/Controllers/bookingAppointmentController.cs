using AC_Service_API.Database;
using AC_Service_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AC_Service_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bookingAppointmentController : ControllerBase
    {
        private readonly AC_ServerDbContext _context;
        public bookingAppointmentController(AC_ServerDbContext ac_serverDbContext)
        {
            _context = ac_serverDbContext;

        }
        [HttpGet("appointments/{id:int}")]
        public async Task<IActionResult> getAppointment(int id)
        {
            var appointment = await _context.Products.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

    }
    
}
