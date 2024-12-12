using System.Threading.Tasks;
using LearningProject.Data;
using LearningProject.Models;
using Microsoft.EntityFrameworkCore;

public class ExamVariantRepository : IExamVariantRepository
{
    private readonly ApplicationDbContext _context;

    public ExamVariantRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // Adds a new Exam Variant
    public async Task AddExamVariantAsync(ExamVariant examVariant)
    {
        _context.ExamVariants.Add(examVariant);
        await _context.SaveChangesAsync();
    }

    // Fetches an Exam Variant by its ID
    public async Task<ExamVariant> GetExamVariantByIdAsync(int examVariantId)
    {
        return await _context.ExamVariants.FindAsync(examVariantId);
    }
}
