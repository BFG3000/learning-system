using System.Collections.Generic;
using System.Threading.Tasks;
using LearningProject.Data;
using LearningProject.Dtos;
using LearningProject.Models;
using LearningProject.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearningProject.Services
{
    public class ExamDefinitionService : IExamDefinitionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IExamRepository _examRepository;
        private readonly IExamVariantRepository _examVariantRepository;
        private readonly IExamDefinitionRepository _examDefinitionRepository; 
        private readonly IQuestionExamRepository _questionExamRepository;
        public ExamDefinitionService(ApplicationDbContext context, IExamRepository examRepository, IExamVariantRepository examVariantRepository, IExamDefinitionRepository examDefinitionRepository,IQuestionExamRepository questionExamRepository)
        {
            _context = context;
            _examRepository = examRepository;
            _examVariantRepository = examVariantRepository;
            _examDefinitionRepository = examDefinitionRepository;
            _questionExamRepository = questionExamRepository;
        }

        // Creates an ExamDefinition with associated Exams and ExamVariants in a single transaction
        public async Task<bool> CreateExamDefinitionWithDetails(ExamDefinition examDefinition, ExamCreationDto examCreation)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Step 1: Create Exam Definition
                await _examDefinitionRepository.AddExamDefinitionAsync(examDefinition);

                // Step 2: Create Exams and their Variants
                foreach (var examDto in examCreation.Exams)
                {
                    var exam = new Exam
                    {
                        Name = examDto.Name,
                        ExamDefinitionId = examDefinition.Id,
                        StartDate = examDto.StartDate,
                        EndDate = examDto.EndDate,
                        LocationId = examDto.LocationID
                    };

                    await _examRepository.AddExamAsync(exam);

                    foreach (var variantDto in examCreation.ExamVariants)
                    {
                        var examVariant = new ExamVariant
                        {
                            Name = variantDto.VariantName,
                            ExamDefinitionId = exam.Id
                        };

                        
                        await _examVariantRepository.AddExamVariantAsync(examVariant);

                        // add exam questions
                        // TODO ADD Question first if it doesnt exists
                        foreach (var question in variantDto.Questions)
                        {
                            var examQuestion = new ExamQuestion{
                                ExamVariantId = examVariant.Id,
                                QuestionId = question.Id
                            };
                            await _questionExamRepository.AddQuestionExamAsync(examQuestion);
                        }
                    }
                }

                // Commit transaction
                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                // Rollback transaction on error
                await transaction.RollbackAsync();
                return false;
            }
        }

        // Retrieve an exam definition by its ID
        public async Task<ExamDefinition> GetExamDefinitionByIdAsync(int id)
        {
            return await _examDefinitionRepository.GetExamDefinitionByIdAsync(id);
        }

        // Retrieve all exam definitions
        public async Task<List<ExamDefinition>> GetAllExamDefinitionsAsync()
        {
            return await _examDefinitionRepository.GetAllExamDefinitionsAsync();
        }
    }
}