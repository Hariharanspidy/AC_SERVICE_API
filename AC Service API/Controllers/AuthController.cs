using AC_Service_API.Database;
using AC_Service_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace loginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class AuthController : ControllerBase
    {
        private readonly AC_ServerDbContext _context;
        public AuthController(AC_ServerDbContext ac_serverDbContext)
        {
            _context = ac_serverDbContext;

        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginModel userobj)
        {
            if (userobj == null)
            {
                return BadRequest();
            }
            var user = await _context.Users.FirstOrDefaultAsync(x => x.email == userobj.email && x.password == userobj.password);
            if (user == null)
            {
                return NotFound(new { Message = "Account not found" });
            }
            return Ok(new
            {
                Message = "login_Success",
                userRole = user.userRole
            });
        }
        //[HttpPost("register")]
        //public async Task<IActionResult> Register([FromBody] UserModel userobj)
        //{
        //    if (userobj == null)
        //    {
        //        return BadRequest();
        //    }
        //    await _context.Users.AddAsync(userobj);
        //    await _context.SaveChangesAsync();
        //    return Ok(new
        //    {
        //        Message = "user registerd"
        //    });

        //}
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserModel userobj)
        {
            if (userobj == null)
            {
                return BadRequest();
            }

            // Add the user to the Users table
            await _context.Users.AddAsync(userobj);
            await _context.SaveChangesAsync();

            // If the user's role is admin, create an instance of AdminModel with relevant information
            if (userobj.userRole == "admin")
            {
                var adminObj = new AdminModel
                {
                    email = userobj.email,
                    password = userobj.password,
                    mobileNumber = userobj.mobileNumber,
                    userRole = userobj.userRole
                };

                // Add the admin to the Admins table
                await _context.Admins.AddAsync(adminObj);
                await _context.SaveChangesAsync();
            }

            // Create a LoginModel object with the registered user's email and password
            var loginObj = new LoginModel
            {
                email = userobj.email,
                password = userobj.password
            };
            await _context.LoginModels.AddAsync(loginObj);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "User registered",
                Login = loginObj
            });
        }
    }
}
