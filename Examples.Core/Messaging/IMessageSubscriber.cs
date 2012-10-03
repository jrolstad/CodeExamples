using System;

namespace Examples.Core.Messaging
{
    public interface IMessageSubscriber<T> : IDisposable
    {
        void Subscribe(Action<IMessageContext<T>> messageHandler);

        bool IsSubscribed { get; }

        void Unsubscribe();

    }
}