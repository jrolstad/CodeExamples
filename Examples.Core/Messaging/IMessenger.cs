using System;

namespace Examples.Core.Messaging
{
    public interface IMessenger : IDisposable
    {
        void Send<T>(T message);
    }
}