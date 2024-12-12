using System.Threading.Tasks;
using LearningProject.Data;
using LearningProject.Models;
using Microsoft.EntityFrameworkCore;

public class ExamRepository : IExamRepository
{
    private readonly ApplicationDbContext _context;

    public ExamRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // Adds a new Exam
    public async Task AddExamAsync(Exam exam)
    {
        _context.Exams.Add(exam);
        await _context.SaveChangesAsync();
    }

    // Fetches an Exam by its ID
    public async Task<Exam> GetExamByIdAsync(int examId)
    {
        return await _context.Exams.FirstAsync(e=>e.Id == examId);
    }
}
