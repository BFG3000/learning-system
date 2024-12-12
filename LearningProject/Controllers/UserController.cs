using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningProject.Data;
using LearningProject.Models;

namespace LearningProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var User = await _context.Users.FindAsync(id);

            if (User == null)
            {
                return NotFound();
            }

            return User;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User User)
        {
            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = User.Id }, User);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User User)
        {
            if (id != User.Id)
            {
                return BadRequest();
            }

            _context.Entry(User).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var User = await _context.Users.FindAsync(id);
            if (User == null)
            {
                return NotFound();
            }

            _context.Users.Remove(User);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPost("register")]
        // public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        // {
        //     //var result = await _authService.RegisterAsync(registerDto);
        //     // if (result.Succeeded))
        //     //     return Ok(result.Data);
        //     // return BadRequest(result.Errors);
        //     return Ok();
        // }

        // [HttpPost("create")]
        // public async Task<ActionResult<User>> CreatePublicUser([FromBody] PublicUserDTO publicUserDto)
        // {
        //     // Create a new User entry (common fields for both internal and public users)
        //     var user = new User
        //     {
        //         Name = publicUserDto.Name,
        //         Email = publicUserDto.Email,
        //         Type = UserType.Public
        //     };

        //     _context.Users.Add(user);
        //     await _context.SaveChangesAsync();

        //     // Now create a PublicUser entry with user-specific fields
        //     var publicUser = new PublicUser
        //     {
        //         Id = user.Id,
        //         RegistrationDate = DateTime.Now,
        //         Address = publicUserDto.Address,
        //         PhoneNumber = publicUserDto.PhoneNumber,
        //         PreferredLanguage = publicUserDto.PreferredLanguage,
        //         IsSubscribedToNewsletter = publicUserDto.IsSubscribedToNewsletter
        //     };

        //     _context.PublicUsers.Add(publicUser);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        // }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
