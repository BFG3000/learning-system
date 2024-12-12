using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using LearningProject.Data;
using LearningProject.Models;

namespace LearningProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ResultController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{userExamId}")]
        public async Task<ActionResult<Result>> GetResult(int userExamId)
        {
            var result = await _context.Results
                                        .Where(r => r.Id == userExamId)
                                        .Include(r => r.ExamVariant)
                                        .FirstOrDefaultAsync();

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Result>> PostResult(Result result)
        {
            // Ensure we track both EmpExamID and ExamVariantID
            _context.Results.Add(result);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetResult), new { UserExamId = result.Id }, result);
        }
    }
}
