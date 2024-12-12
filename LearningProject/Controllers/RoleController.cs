using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningProject.Models;
using LearningProject.Data;

namespace LearningProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RoleController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var Role = await _context.Roles.FindAsync(id);

            if (Role == null)
            {
                return NotFound();
            }

            return Role;
        }

        [HttpPost]
        public async Task<ActionResult<Role>> PostRole(Role Role)
        {
            _context.Roles.Add(Role);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRole), new { id = Role.Id }, Role);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, Role Role)
        {
            if (id != Role.Id)
            {
                return BadRequest();
            }

            _context.Entry(Role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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
        public async Task<IActionResult> DeleteRole(int id)
        {
            var Role = await _context.Roles.FindAsync(id);
            if (Role == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(Role);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoleExists(int id)
        {
            return _context.Roles.Any(qt => qt.Id == id);
        }
    }
}
