namespace LearningProject.Dtos {
    public class UserDto {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }

        public UserType Type { get; set; }  // Enum to distinguish Public/Internal users

        // Navigation properties
        public InternalUserDto InternalUser { get; set; }  // Linked for internal users
        public PublicUserDto PublicUser { get; set; }  // Linked for public users

    }
}