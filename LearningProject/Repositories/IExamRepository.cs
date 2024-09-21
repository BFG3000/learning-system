using System.Threading.Tasks;
using LearningProject.Models;

public interface IExamRepository
{
    // Method to add a new Exam
    Task AddExamAsync(Exam exam);

    // Method to fetch an Exam by ID
    Task<Exam> GetExamByIdAsync(int examId);
}
