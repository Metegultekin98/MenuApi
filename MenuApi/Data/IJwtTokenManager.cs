namespace MenuApi.Data
{
    public interface IJwtTokenManager
    {
        string Authenticate(string username, string password);
    }
}
