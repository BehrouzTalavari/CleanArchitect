using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Core.Extensions
{
    public class ErrorDetails
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public string MessageId { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings()
            { ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }

    }
}
