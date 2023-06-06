using AC_Service_API.Database;
using AC_Service_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AC_Service_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCenterController : ControllerBase
    {
        private readonly AC_ServerDbContext _context;
        public ServiceCenterController(AC_ServerDbContext ac_serverDbContext)
        {
            _context = ac_serverDbContext;

        }
        [HttpPost("addServiceCenter")]
        public async Task<IActionResult> addServiceCenter([FromBody] ServiceCenterModel serviceCenterModel)
        {
            if (serviceCenterModel == null)
            {
                return BadRequest();
            }
            await _context.Services.AddAsync(serviceCenterModel);
            await _context.SaveChangesAsync();
            string tableName = $"ServiceCenter{serviceCenterModel.Id}";
            string createTableSql = $"CREATE TABLE {tableName} (Id INT PRIMARY KEY, Name VARCHAR(255))";
            _context.Database.ExecuteSqlRaw(createTableSql);

            // Add some data to the newly created table
            string insertDataSql = $"INSERT INTO {tableName} (Id, Name) VALUES (1, 'Some Data')";
            _context.Database.ExecuteSqlRaw(insertDataSql);
            return Ok(new
            {
                Message = "Service center added"
            });

        }
        [HttpGet("serviceCenter")]
        public async Task<IActionResult> viewServiceCenter()
        {
            var serviceCenter = await _context.Services.ToListAsync();

            if (serviceCenter == null)
            {
                return NotFound();
            }

            return Ok(serviceCenter);
        }

        [HttpPut("serviceCenter,{id:int}")]
        public async Task<IActionResult> editServiceCenter(int id, [FromBody] ServiceCenterModel serviceCenterModel)
        {
            if (serviceCenterModel == null || id != serviceCenterModel.Id)
            {
                return BadRequest();
            }

            var serviceCenter = await _context.Services.FindAsync(id);

            if (serviceCenter == null)
            {
                return NotFound();
            }

            serviceCenter.serviceCenterName = serviceCenterModel.serviceCenterName;
            serviceCenter.serviceCenterPhone = serviceCenterModel.serviceCenterPhone;
            serviceCenter.serviceCenterAddress = serviceCenterModel.serviceCenterAddress;
            serviceCenter.serviceCenterImageUrl = serviceCenterModel.serviceCenterImageUrl;
            serviceCenter.serviceCenteramailId = serviceCenterModel.serviceCenteramailId;
            serviceCenter.serviceCenterDescription = serviceCenterModel.serviceCenterDescription;

            _context.Services.Update(serviceCenter);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "Service center updated"
            });
        }
        [HttpDelete("serviceCenter/{id}")]
        public async Task<IActionResult> deleteServiceCenter(int id)
        {
            var serviceCenter = await _context.Services.FindAsync(id);

            if (serviceCenter == null)
            {
                return NotFound();
            }

            _context.Services.Remove(serviceCenter);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "Service center deleted"
            });
        }







    }
}
