using LearningProject.Data;
using LearningProject.Models;

namespace LearningProject.Repositories
{
    public class QuestionExamRepository : IQuestionExamRepository
    {
        public readonly ApplicationDbContext _context;
        public QuestionExamRepository (ApplicationDbContext context){
            _context = context;
        }
        public async Task AddQuestionExamAsync(ExamQuestion examQuestion)
        {
            _context.Add(examQuestion);
            await _context.SaveChangesAsync();
        }
    }
}