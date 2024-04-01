namespace App.UI.Configurations
{
    public class DatabaseOptions
    {
        public int MaxRetryCount { get; set; }

        public int CommandTimeout { get; set; }

        public bool EnableDetailedErrors { get; set; }

        public bool EnableSensitiveDataLogging { get; set; }
    }
}