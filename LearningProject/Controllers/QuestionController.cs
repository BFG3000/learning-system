using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using LearningProject.Models;
using System.Linq;
using System.Threading.Tasks;
using LearningProject.Data;

namespace LearningProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuestionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Question
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
            // Fetch all questions
            var questions = await _context.Questions
                                          .Include(q => q.Answers)  // Optionally include related answers
                                          .Include(q => q.QuestionType)  // Optionally include QuestionType
                                          .ToListAsync();

            return Ok(questions);
        }

        // GET: api/Question/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            var question = await _context.Questions
                                         .Include(q => q.Answers)  // Optionally include related answers
                                         .Include(q => q.QuestionType)  // Optionally include QuestionType
                                         .FirstOrDefaultAsync(q => q.Id == id);

            if (question == null)
            {
                return NotFound($"Question with ID {id} not found.");
            }

            return Ok(question);
        }

        // POST: api/Question
        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion([FromBody] Question question)
        {
            // Ensure the related QuestionType exists
            var questionType = await _context.QuestionTypes.FindAsync(question.QuestionTypeId);
            if (questionType == null)
            {
                return BadRequest($"Question Type with ID {question.QuestionTypeId} does not exist.");
            }

            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetQuestion), new { id = question.Id }, question);
        }

        // PUT: api/Question/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, [FromBody] Question question)
        {
            if (id != question.Id)
            {
                return BadRequest("Question ID mismatch.");
            }

            // Ensure the related QuestionType exists
            var questionType = await _context.QuestionTypes.FindAsync(question.QuestionTypeId);
            if (questionType == null)
            {
                return BadRequest($"Question Type with ID {question.QuestionTypeId} does not exist.");
            }

            _context.Entry(question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
                {
                    return NotFound($"Question with ID {id} not found.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Question/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound($"Question with ID {id} not found.");
            }

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(q => q.Id == id);
        }
    }
}
