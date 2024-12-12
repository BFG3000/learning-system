namespace LearningProject.Dtos
{
    public class ExamVariantDTO
    {
        public required string VariantName { get; set; }
        public List<QuestionDto>? Questions { get; set; }
    }
}
