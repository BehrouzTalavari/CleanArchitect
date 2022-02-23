namespace Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class JsonFileLogger : LoggerServiceBase
    {
        public JsonFileLogger() : base(nameof(JsonFileLogger))
        {
        }
    }
    public class DatabaseLogger : LoggerServiceBase
    {
        public DatabaseLogger() : base(nameof(DatabaseLogger))
        {
        }
    }
}
