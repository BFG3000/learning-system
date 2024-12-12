namespace LearningProject.Dtos {
    public class PublicUserDto {
        public int? Id { get; set; }
        public int? UserId { get; set; }  // Foreign Key from User table

        public DateTime RegistrationDate { get; set; }

    }
}