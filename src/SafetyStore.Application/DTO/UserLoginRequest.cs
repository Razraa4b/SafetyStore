namespace SafetyStore.Application.DTO
{
    public class UserLoginRequest
    {
        public required string NameOrEmail { get; set; }
        public required string Password { get; set; }
    }
}
