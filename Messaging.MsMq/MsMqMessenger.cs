using System.Messaging;
using Examples.Core.Messaging;

namespace Messaging.MsMq
{
    public class MsMqMessenger:IMessenger
    {
        private readonly string _uri;
        private readonly IMessageFormatter _messageFormatter;

        public MsMqMessenger(string uri, IMessageFormatter messageFormatter)
        {
            _uri = uri;
            _messageFormatter = messageFormatter;
        }

        public void Dispose()
        {
            // Nothing to see here. Move along.
        }

        public void Send<T>(T message)
        {
            var messageQueue = new MessageQueue(_uri, QueueAccessMode.Receive) { Formatter = _messageFormatter };

            messageQueue.Send(message);
        }
    }
}