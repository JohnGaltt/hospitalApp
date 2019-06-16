namespace Hospital.Core.DataAccess
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; }
        public int MaxRetryCount { get; set; } = 10;
        public int MaxRetryDelay { get; set; } = 1;
    }
}
