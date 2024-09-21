namespace LearningProject.Models
{
public class ExamDefinition
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int CategoryId { get; set; }
    public int Duration { get; set; }
    public int ExamTypeId { get; set; } 
    public ExamType? ExamType { get; set; }
    public ICollection<ExamVariant>? ExamVariants { get; set; }
    public ICollection<Exam>? Exams { get; set; }
    public Category? Category { get; set; }
}
}