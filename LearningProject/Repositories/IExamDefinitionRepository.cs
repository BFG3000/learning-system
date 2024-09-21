using System.Threading.Tasks;
using LearningProject.Models;

namespace LearningProject.Repositories
{
    public interface IExamDefinitionRepository
    {
        Task<ExamDefinition> AddExamDefinitionAsync(ExamDefinition examDefinition);
        Task<ExamDefinition> GetExamDefinitionByIdAsync(int examDefinitionId);
        Task<List<ExamDefinition>> GetAllExamDefinitionsAsync();
    }
}
