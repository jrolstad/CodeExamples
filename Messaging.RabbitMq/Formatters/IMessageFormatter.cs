namespace Messaging.RabbitMq
{
    public interface IMessageFormatter
    {
        byte[] Write<T>(T message);

        T Read<T>(byte[] message);

        string GetMIMEContentType();
    }
}