using AC_Service_API.Database;
using AC_Service_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AC_Service_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AC_ServerDbContext _context;
        public AppointmentController(AC_ServerDbContext dbcontext)
        {
            _context = dbcontext;
        }
        [HttpPost("appointment_booking")]
        public async Task<IActionResult> saveAppointment([FromBody] ProductModel productModel)
        {
            if (productModel == null)
            {
                return BadRequest();
            }
            await _context.Products.AddAsync(productModel);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                Message = "Appointment booked"
            });

        }
        [HttpPut("appointment_editing,{id:int}")]
        public async Task<IActionResult> EditAppointment(int id, [FromBody] ProductModel productModel)
        {
            if (productModel == null || id != productModel.Id)
            {
                return BadRequest();
            }

            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            product.productName = productModel.productName;
            product.ProductModelNo = productModel.ProductModelNo;
            product.ProductDateOfPurchase = productModel.ProductDateOfPurchase;
            product.contactNumber = productModel.contactNumber;
            product.problemDescription = productModel.problemDescription;
            product.availableSlots = productModel.availableSlots;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "Appointment updated"
            });
        }
        [HttpDelete("appointdelete,{id:int}")]
        public async Task<IActionResult> deleteAppointment(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "Appointment deleted"
            });
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
