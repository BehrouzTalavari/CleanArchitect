using System;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class LogParameter
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public string Type { get; set; }
    }
}
