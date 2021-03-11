using System;
using System.Threading.Tasks;
using zadanie3.api.BindingModels;
using zadanie3.api.Validation;
using zadanie3.api.ViewModels;
using zadanie3.Data.SQL;
using zadanie3.Data.SQL.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace zadanie3.api.Controllers
{
     [ApiVersion( "1.0" )]
    [Route( "api/v{version:apiVersion}/[controller]" )]

    public class UserController : Controller
    {
        private readonly SklepDbContext _context;

        public UserController(SklepDbContext context)
        {
            _context = context;
        }
        
        [HttpGet("{userId:min(1)}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _context.User.FirstOrDefaultAsync(x=>x.UserId == userId);

            if (user != null)
            {
                return Ok(new UserViewModel
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Name = user.Name,
                    Email = user.Email,
                    Gender = user.Gender,
                    BirthDate = user.BirthDate,
                    RegistrationDate = user.RegistrationDate
                   });
            }
            return NotFound();
        }
        
        [HttpGet("name/{userName}", Name = "GetUserByUsername")]
        public async Task<IActionResult> GetUserByUsername(string userName)
        {
            var user = await _context.User.FirstOrDefaultAsync(x=>x.Username == userName);

            if (user != null)
            {
                return Ok(new UserViewModel
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Name = user.Name,
                    Email = user.Email,
                    Gender = user.Gender,
                    BirthDate = user.BirthDate,
                    RegistrationDate = user.RegistrationDate
                   
                });
            }
            return NotFound();
        }
        
        [ValidateModel]
//        [Consumes("application/x-www-form-urlencoded")]
//        [HttpPost("create", Name = "CreateUser")]
        public async Task<IActionResult> Post([FromBody] CreateUser createUser)
        {
            var user = new User { 
                Username = createUser.Username,
                Name = createUser.Name,
                Email = createUser.Email,
                Gender = createUser.Gender,
                BirthDate = createUser.BirthDate,
                RegistrationDate = DateTime.UtcNow};
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            
            return Created(user.UserId.ToString(),new UserViewModel
            {
                UserId = user.UserId,
                Username = user.Username,
                Name = user.Name,
                Email = user.Email,
                Gender = user.Gender,
                BirthDate = user.BirthDate,
                RegistrationDate = user.RegistrationDate
            }) ;
        }
        
        [ValidateModel]
        [HttpPatch("edit/{userId:min(1)}", Name = "EditUser")]
        public async Task<IActionResult> EditUser([FromBody] EditUser editUser, int userId)
        {
            var user = await _context.User.FirstOrDefaultAsync(x=>x.UserId == userId);
            user.Username = editUser.Username;
            user.Name = editUser.Name;
            user.Email = editUser.Email;
            user.BirthDate = editUser.BirthDate;
            user.Gender = editUser.Gender;
            await _context.SaveChangesAsync();
            return NoContent();
            return Ok(new UserViewModel
            {
                UserId = user.UserId,
                Username = user.Username,
                Name = user.Name,
                Email = user.Email,
                Gender = user.Gender,
                BirthDate = user.BirthDate,
                RegistrationDate = user.RegistrationDate
            });
        }
        
        [HttpDelete("delete/{userId:min(1)}", Name = "DeleteUser")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var user = await _context.User.FirstOrDefaultAsync(x=>x.UserId == userId);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}