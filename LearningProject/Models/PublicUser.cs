using System.ComponentModel.DataAnnotations;

namespace LearningProject.Models
{
    public class PublicUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }  // Foreign Key from User table


        [Required]
        public DateTime RegistrationDate { get; set; }

        // Navigation properties
        public User User { get; set; }  // Reference to User table
    }
}
