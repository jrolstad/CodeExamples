using System;

namespace Examples.Core.Commands
{
    /// <summary>
    /// Extensions for commands
    /// </summary>
    public static class CommandExtensions
    {
        /// <summary>
        /// Wraps a given command with exception handling
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="baseCommand"></param>
        /// <param name="exceptionHandlingStrategy"></param>
        /// <returns></returns>
        public static ICommand<TIn, TOut> WithExceptionHandling<TIn, TOut>(this ICommand<TIn, TOut> baseCommand, ICommand<Exception, Response> exceptionHandlingStrategy)
        {
            return new ExceptionHandlingCommand<TIn, TOut>(baseCommand, exceptionHandlingStrategy);
        }
    }
}