using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using LearningProject.Models;

using LearningProject.Data;
using System.Collections.Generic;

namespace LearningProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamVariantController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExamVariantController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{examId}")]
        public async Task<ActionResult<IEnumerable<ExamVariant>>> GetExamVariants(int examId)
        {
            return await _context.ExamVariants
                                 .Where(ev => ev.ExamDefinitionId == examId)
                                 .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ExamVariant>> PostExamVariant(ExamVariant examVariant)
        {
            _context.ExamVariants.Add(examVariant);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExamVariants), new { examId = examVariant.ExamDefinitionId }, examVariant);
        }

        [HttpPost("{examId}/assign-random")]
        public async Task<ActionResult<ExamVariant>> AssignRandomVariant(int examId)
        {
            // Fetch all variants for this exam
            var variants = await _context.ExamVariants
                                         .Where(ev => ev.ExamDefinitionId == examId)
                                         .ToListAsync();

            if (!variants.Any())
            {
                return NotFound("No variants found for this exam.");
            }

            // Randomly select one of the variants
            var random = new Random();
            int index = random.Next(variants.Count);

            var assignedVariant = variants[index];

            // Return the assigned variant (this will be used when storing the result later)
            return Ok(assignedVariant);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamVariant(int id)
        {
            var examVariant = await _context.ExamVariants.FindAsync(id);
            if (examVariant == null)
            {
                return NotFound();
            }

            _context.ExamVariants.Remove(examVariant);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
