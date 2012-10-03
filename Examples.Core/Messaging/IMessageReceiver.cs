using System;

namespace Examples.Core.Messaging
{
    public interface IMessageReceiver: IDisposable
    {
        void ProcessMessage<T>(IMessageContext<T> context);
    }
}