using System.Threading.Tasks;
using LearningProject.Models;

public interface IQuestionExamRepository
{
    // Method to add a new Exam Question
    Task AddQuestionExamAsync(ExamQuestion examQuestion);

}
