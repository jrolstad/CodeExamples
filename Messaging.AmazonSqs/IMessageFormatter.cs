using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Messaging.AmazonSqs
{
    public interface IMessageFormatter
    {
        string Write<T>(T message);

        T Read<T>(string body);
    }
}
