using System;

namespace Examples.Core.Messaging
{
    public interface IMessageQueueDetailFactory: IDisposable
    {
        MessageQueueDetail Build(string uri);
    }
}