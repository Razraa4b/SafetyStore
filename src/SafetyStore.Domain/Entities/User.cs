using SafetyStore.Domain.Enums;

namespace SafetyStore.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public UserRole Role { get; set; } = UserRole.Client;
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
    }
}
