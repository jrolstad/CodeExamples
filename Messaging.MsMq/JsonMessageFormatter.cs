using System;
using System.Messaging;
using Newtonsoft.Json;

namespace Messaging.MsMq
{
    public class JsonMessageFormatter:IMessageFormatter
    {
        public object Clone()
        {
            return this;
        }

        public bool CanRead(Message message)
        {
            try
            {
                Read(message);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public object Read(Message message)
        {
            var body = JsonConvert.DeserializeObject(message.Body.ToString());

            return body;
        }

        public void Write(Message message, object obj)
        {
            var body = JsonConvert.SerializeObject(obj);

            message.Body = body;
        }
    }
}