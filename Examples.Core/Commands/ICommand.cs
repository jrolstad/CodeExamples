using System;

namespace Examples.Core.Commands
{
    public interface ICommand<in TRequest, out TResponse> : IDisposable
    {
        TResponse Execute(TRequest request);
    }
}