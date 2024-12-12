using System.ComponentModel.DataAnnotations;

namespace LearningProject.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        public int Name { get; set; }
    }

}