using System.Threading.Tasks;
using LearningProject.Models;

public interface IExamVariantRepository
{
    // Method to add a new Exam Variant
    Task AddExamVariantAsync(ExamVariant examVariant);

    // Method to fetch an Exam Variant by ID
    Task<ExamVariant> GetExamVariantByIdAsync(int examVariantId);
}
