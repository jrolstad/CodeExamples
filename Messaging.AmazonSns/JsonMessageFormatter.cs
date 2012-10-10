using Newtonsoft.Json;

namespace Messaging.AmazonSns
{
    public class JsonMessageFormatter:IMessageFormatter
    {
        public string Write<T>(T message)
        {
            return JsonConvert.SerializeObject(message);
        }

        public T Read<T>(string body)
        {
            return JsonConvert.DeserializeObject<T>(body);
        }
    }
}