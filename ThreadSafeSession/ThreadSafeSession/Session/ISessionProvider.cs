namespace ThreadSafeSession.Session
{
    public interface ISessionProvider
    {
        void Set<T>(string key, T value);
        T Get<T>(string key);
    }
}
