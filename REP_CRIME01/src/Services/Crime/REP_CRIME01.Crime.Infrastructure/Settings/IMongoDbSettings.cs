namespace REP_CRIME01.Crime.Infrastructure.Settings
{
    public interface IMongoDbSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
