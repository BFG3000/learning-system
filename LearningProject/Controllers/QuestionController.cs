using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningProject.Data;
using LearningProject.Models;
using LearningProject.Dtos;

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
        public async Task<ActionResult<IEnumerable<QuestionDto>>> GetQuestions()
        {
            // Fetch all questions including their related answers and question types
            var questions = await _context.Questions
                                          .Include(q => q.Answers)
                                          .Include(q => q.QuestionType)
                                          .ToListAsync();

            // Map the entities to DTOs
            var questionDtos = questions.Select(q => new QuestionDto
            {
                Id = q.Id,
                Name = q.Name,
                Marks = q.Marks,
                IsPublic = q.IsPublic,
                QuestionTypeName = q.QuestionType?.Name,  // Map the QuestionType name
                Answers = q.Answers?.Select(a => new AnswerDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    IsCorrect = a.IsCorrect
                }).ToList()
            }).ToList();

            return Ok(questionDtos);
        }

        // GET: api/Question/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionDto>> GetQuestion(int id)
        {
            // Fetch the specific question along with its related answers and question type
            var question = await _context.Questions
                                         .Include(q => q.Answers)
                                         .Include(q => q.QuestionType)
                                         .FirstOrDefaultAsync(q => q.Id == id);

            if (question == null)
            {
                return NotFound($"Question with ID {id} not found.");
            }

            // Map to DTO
            var questionDto = new QuestionDto
            {
                Id = question.Id,
                Name = question.Name,
                Marks = question.Marks,
                IsPublic = question.IsPublic,
                QuestionTypeName = question.QuestionType?.Name,
                Answers = question.Answers?.Select(a => new AnswerDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    IsCorrect = a.IsCorrect
                }).ToList()
            };

            return Ok(questionDto);
        }

        // POST: api/Question
        [HttpPost]
        public async Task<ActionResult<QuestionDto>> PostQuestion([FromBody] Question question)
        {
            // Ensure the related QuestionType exists
            var questionType = await _context.QuestionTypes.FindAsync(question.QuestionTypeId);
            if (questionType == null)
            {
                return BadRequest($"Question Type with ID {question.QuestionTypeId} does not exist.");
            }

            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            // Map to DTO after creation
            var questionDto = new QuestionDto
            {
                Id = question.Id,
                Name = question.Name,
                Marks = question.Marks,
                IsPublic = question.IsPublic,
                QuestionTypeName = questionType.Name, 
                Answers = question.Answers?.Select(a => new AnswerDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    IsCorrect = a.IsCorrect
                }).ToList()
            };

            return CreatedAtAction(nameof(GetQuestion), new { id = question.Id }, questionDto);
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
