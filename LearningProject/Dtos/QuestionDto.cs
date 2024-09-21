namespace LearningProject.Dtos
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string? QuestionText { get; set; }
        public int? Marks { get; set; }
        public string? Level { get; set; }
        public int? QuestionTypeId { get; set; }
    }
}
