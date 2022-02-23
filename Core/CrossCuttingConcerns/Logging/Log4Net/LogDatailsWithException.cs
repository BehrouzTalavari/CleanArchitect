using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class LogDatailsWithException:LogDetails
    {
        public string ExceptionMessage { get; set; }
    }
}
