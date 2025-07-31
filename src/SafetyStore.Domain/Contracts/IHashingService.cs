namespace SafetyStore.Domain.Contracts
{
    public interface IHashingService
    {
        string Hash(string input);
    }
}
