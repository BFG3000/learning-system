using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LearningProject.Data;
using LearningProject.Models;

namespace LearningProject.Repositories
{
    public class ExamDefinitionRepository : IExamDefinitionRepository
    {
        private readonly ApplicationDbContext _context;

        public ExamDefinitionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ExamDefinition> AddExamDefinitionAsync(ExamDefinition examDefinition)
        {
            _context.ExamDefinitions.Add(examDefinition);
            await _context.SaveChangesAsync();
            return examDefinition;
        }

        public async Task<List<ExamDefinition>> GetAllExamDefinitionsAsync()
        {
            return await _context.ExamDefinitions.ToListAsync();
        }

        public async Task<ExamDefinition> GetExamDefinitionByIdAsync(int examDefinitionId)
        {
            return await _context.ExamDefinitions
                                 .Include(ed => ed.Exams)
                                 .Include(e => e.ExamVariants)
                                 .FirstAsync(ed => ed.Id == examDefinitionId);
        }
    }
}
