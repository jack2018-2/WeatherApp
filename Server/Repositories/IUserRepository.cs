namespace Server.Repositories
{
    public interface IUserRepository
    {
        Task<bool> Authenticate(string login, string password);
        Task<IEnumerable<User>> Get();
        Task<IEnumerable<User>> Get(int id);
    }
}