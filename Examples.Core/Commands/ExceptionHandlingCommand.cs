using System;

namespace Examples.Core.Commands
{
    /// <summary>
    /// Command that wraps handling exceptions
    /// </summary>
    /// <typeparam name="TIn"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    public class ExceptionHandlingCommand<TIn, TOut> : ICommand<TIn, TOut>
    {
        private readonly ICommand<TIn, TOut> _baseCommand;
        private readonly ICommand<Exception, Response> _exceptionHandlingStrategy;

        /// <summary>
        /// Constructor with argments
        /// </summary>
        /// <param name="baseCommand">Command to do the work</param>
        /// <param name="exceptionHandlingStrategy">Exception handling strategy</param>
        public ExceptionHandlingCommand(ICommand<TIn, TOut> baseCommand, ICommand<Exception, Response> exceptionHandlingStrategy)
        {
            _baseCommand = baseCommand;
            _exceptionHandlingStrategy = exceptionHandlingStrategy;
        }

        /// <summary>
        /// Executs a given command and handles any exceptions with the exception strategy
        /// </summary>
        /// <param name="request">Request to execute on</param>
        /// <returns></returns>
        public TOut Execute(TIn request)
        {
            try
            {
                var result = _baseCommand.Execute(request);
                return result;
            }
            catch (Exception exception)
            {
                _exceptionHandlingStrategy.Execute(exception);

                throw;
            }
        }

        public void Dispose()
        {
            // do nothing
        }
    }
}