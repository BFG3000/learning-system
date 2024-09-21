using System.ComponentModel.DataAnnotations;

namespace LearningProject.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required]
        public UserType Type { get; set; }  // Enum to distinguish Public/Internal users

        // Navigation properties
        public InternalUser InternalUser { get; set; }  // Linked for internal users
        public PublicUser PublicUser { get; set; }  // Linked for public users
    }
}

public enum UserType
{
    Public,    // For public users
    Internal   // For internal users (employees)
}
