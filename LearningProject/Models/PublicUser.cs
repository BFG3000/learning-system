using System.ComponentModel.DataAnnotations;

namespace LearningProject.Models
{
    public class PublicUser
    {
        public int Id { get; set; }
        public int UserId { get; set; } 


        [Required]
        public DateTime RegistrationDate { get; set; }

        // Navigation properties
        public User? User { get; set; } 
    }
}
