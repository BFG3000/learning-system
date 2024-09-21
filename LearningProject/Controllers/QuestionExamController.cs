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
    public class QuestionExamController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuestionExamController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/QuestionExam/variant/{variantId}
        [HttpGet("variant/{variantId}")]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestionsForVariant(int variantId)
        {
            // Fetch all questions linked to the specified ExamVariant via QuestionExam table
            var questions = await _context.ExamQuestions
                                          .Where(qe => qe.ExamVariantId == variantId)
                                          .Include(qe => qe.Question)
                                          .Select(qe => qe.Question)  // Extract only questions
                                          .ToListAsync();

            return Ok(questions);
        }

        // POST: api/QuestionExam
        [HttpPost]
        public async Task<ActionResult<ExamQuestion>> PostQuestionExam([FromBody] ExamQuestion examQuestion)
        {
            // Ensure the related ExamVariant exists
            var examVariant = await _context.ExamVariants.FindAsync(examQuestion.ExamVariantId);
            if (examVariant == null)
            {
                return BadRequest($"ExamVariant with ID {examQuestion.ExamVariantId} does not exist.");
            }

            // Ensure the related Question exists
            var question = await _context.Questions.FindAsync(examQuestion.QuestionId);
            if (question == null)
            {
                return BadRequest($"Question with ID {examQuestion.QuestionId} does not exist.");
            }

            _context.ExamQuestions.Add(examQuestion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetQuestionsForVariant), new { variantId = examQuestion.ExamVariantId }, examQuestion);
        }

        // DELETE: api/QuestionExam/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionExam(int id)
        {
            var questionExam = await _context.ExamQuestions.FindAsync(id);
            if (questionExam == null)
            {
                return NotFound($"QuestionExam entry with ID {id} not found.");
            }

            _context.ExamQuestions.Remove(questionExam);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
