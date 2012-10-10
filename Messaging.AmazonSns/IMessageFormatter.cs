namespace Messaging.AmazonSns
{
    public interface IMessageFormatter
    {
        string Write<T>(T message);

        T Read<T>(string body);
    }
}
