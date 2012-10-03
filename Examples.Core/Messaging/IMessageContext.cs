namespace Examples.Core.Messaging
{
    public interface IMessageContext<T>
    {
        void Accept();

        void Reject();

        T Message { get; set; }
    }
}