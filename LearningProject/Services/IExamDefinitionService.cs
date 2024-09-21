using System.Collections.Generic;
using System.Threading.Tasks;
using LearningProject.Dtos;
using LearningProject.Models;

namespace LearningProject.Services
{
    public interface IExamDefinitionService
    {
        // Method to create an exam definition, its exams, and variants in one transactional operation
        Task<bool> CreateExamDefinitionWithDetails(ExamDefinition examDefinition, ExamCreationDto examCreation);

        // Additional methods for Exam Definition management can go here, such as:
        Task<ExamDefinition> GetExamDefinitionByIdAsync(int id);
        Task<List<ExamDefinition>> GetAllExamDefinitionsAsync();
    }
}
