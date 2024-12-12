namespace LearningProject.Dtos
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Marks { get; set; }
        public bool? IsPublic { get; set; }
        public string? QuestionTypeName { get; set; }
        public List<AnswerDto>? Answers { get; set; }
    }
}
