namespace LearningProject.Models
{
public class AnswerResult
    {
        public int Id { get; set; }
        public int AnswerId { get; set; }
        public int ResultId { get; set; }
        public Answer Answer { get; set; }
        public Result Result { get; set; }
    }
}