namespace LearningProject.Dtos
{
    public class ExamDto
    {
        public int? Id { get; set; }
        public required string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LocationID { get; set; }
        public int? ExamDefinitionID { get; set; }
    }
}