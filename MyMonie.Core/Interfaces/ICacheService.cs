namespace MyMonie.Core.Interfaces;

public interface ICacheService
{
    void AddToken(string key, string value, DateTime expiresAt);
    Task<string> GetToken(string key);
    void RemoveToken(string key);
}