using System.Collections.Generic;

namespace Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class LogDetails
    {
        public string Target { get; set; }
        public string MethodName { get; set; }
        public List<LogParameter> LogParameters { get; set; }
    }
}
