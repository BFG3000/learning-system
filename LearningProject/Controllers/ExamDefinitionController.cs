using System.Threading.Tasks;
using LearningProject.Data;
using LearningProject.Dtos;
using LearningProject.Models;
using LearningProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamDefinitionController : ControllerBase
    {
        private readonly IExamDefinitionService _examDefinitionService;
        private readonly ApplicationDbContext _context;

        public ExamDefinitionController(IExamDefinitionService examDefinitionService, ApplicationDbContext context)
        {
            _examDefinitionService = examDefinitionService;
            _context = context;

        }

        // POST: api/ExamDefinition/create-complete-exam
        [HttpPost("create-complete-exam")]
        public async Task<IActionResult> CreateCompleteExam([FromBody] ExamCreationDto examCreationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var examDefinition = new ExamDefinition
            {
                Name = examCreationDto.ExamDefinitionName,
                Duration = examCreationDto.Duration,
                CategoryId = examCreationDto.CategoryId,
                ExamTypeId = examCreationDto.ExamTypeId
            };

            var result = await _examDefinitionService.CreateExamDefinitionWithDetails(examDefinition, examCreationDto);

            if (result)
            {
                return Ok("Exam Definition, Exams, and Exam Variants created successfully.");
            }

            return StatusCode(500, "An error occurred while creating the exam.");
        }

        // GET: api/ExamDefinition/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamDefinitionDto>>> GetExamDefinitions()
        {
            return await _context.ExamDefinitions
            .Include(e => e.Category)
            .Include(e => e.Exams)
            //    .ThenInclude(e=>e.Location)
            .Include(e => e.ExamType)
            .Include(e => e.ExamVariants)
            .Select(e => new ExamDefinitionDto
            {
                Id = e.Id,
                ExamDefinitionName = e.Name,
                Duration = e.Duration,
                Category = e.Category,
                ExamType = e.ExamType,
                Exams = e.Exams.Select(g => new ExamDto
                {
                    Id = g.Id,
                    Name = g.Name,
                    StartDate = g.StartDate,
                    EndDate = g.EndDate,
                    Location = g.Location.Name
                }).ToList(),
                ExamVariants = e.ExamVariants.Select(v => new ExamVariantDTO
                {
                    Id = v.Id,
                    VariantName = v.Name
                }).ToList()
            }).ToListAsync();
        }

        // GET: api/ExamDefinition/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamDefinition(int id)
        {
            var examDefinition = await _context.ExamDefinitions
                                             .Include(ed => ed.Exams)
                                             .Include(ed => ed.ExamVariants)
                                             .Select(e => new ExamDefinitionDto
                                             {
                                                 Id = e.Id,
                                                 ExamDefinitionName = e.Name,
                                                 Duration = e.Duration,
                                                 Category = e.Category,
                                                 ExamType = e.ExamType,
                                                 Exams = e.Exams.Select(g => new ExamDto
                                                 {
                                                     Id = g.Id,
                                                     Name = g.Name,
                                                     StartDate = g.StartDate,
                                                     EndDate = g.EndDate,
                                                     Location = g.Location.Name
                                                 }).ToList(),
                                                 ExamVariants = e.ExamVariants.Select(v => new ExamVariantDTO
                                                 {
                                                     Id = v.Id,
                                                     VariantName = v.Name
                                                 }).ToList()
                                             })
                                             .FirstOrDefaultAsync(ed => ed.Id == id);

            if (examDefinition == null)
            {
                return NotFound($"Exam Definition with ID {id} not found.");
            }

            return Ok(examDefinition);
        }

        [HttpPost]
        public async Task<ActionResult<ExamDefinition>> PostExamDefinition(ExamDefinition examDefinition)
        {
            _context.ExamDefinitions.Add(examDefinition);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExamDefinition), new { id = examDefinition.Id }, examDefinition);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutExamDefinition(int id, ExamDefinition examDefinition)
        {
            if (id != examDefinition.Id)
            {
                return BadRequest();
            }

            _context.Entry(examDefinition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamDefinitionExists(id))
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
        public async Task<IActionResult> DeleteExamDefinition(int id)
        {
            var examDefinition = await _context.ExamDefinitions.FindAsync(id);
            if (examDefinition == null)
            {
                return NotFound();
            }

            _context.ExamDefinitions.Remove(examDefinition);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool ExamDefinitionExists(int id)
        {
            return _context.ExamDefinitions.Any(ed => ed.Id == id);
        }
    }
}
