namespace LearningProject.Models
{
public class ExamVariant
{
    public int Id { get; set; }
    public int ExamDefinitionId { get; set; }
    public required string Name { get; set; }

    // Navigation property for QuestionExam
    public ICollection<ExamQuestion>? ExamQuestions { get; set; }
    
    public ICollection<Result>? Results { get; set; }
    public ExamDefinition? ExamDefinition { get; set; }
}
}
