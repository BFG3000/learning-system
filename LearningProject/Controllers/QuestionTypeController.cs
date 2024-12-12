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
    public class QuestionTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuestionTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionType>>> GetQuestionTypes()
        {
            return await _context.QuestionTypes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionType>> GetQuestionType(int id)
        {
            var questionType = await _context.QuestionTypes.FindAsync(id);

            if (questionType == null)
            {
                return NotFound();
            }

            return questionType;
        }

        [HttpPost]
        public async Task<ActionResult<QuestionType>> PostQuestionType(QuestionType questionType)
        {
            _context.QuestionTypes.Add(questionType);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetQuestionType), new { id = questionType.Id }, questionType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionType(int id, QuestionType questionType)
        {
            if (id != questionType.Id)
            {
                return BadRequest();
            }

            _context.Entry(questionType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionTypeExists(id))
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
        public async Task<IActionResult> DeleteQuestionType(int id)
        {
            var questionType = await _context.QuestionTypes.FindAsync(id);
            if (questionType == null)
            {
                return NotFound();
            }

            _context.QuestionTypes.Remove(questionType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionTypeExists(int id)
        {
            return _context.QuestionTypes.Any(qt => qt.Id == id);
        }
    }
}
