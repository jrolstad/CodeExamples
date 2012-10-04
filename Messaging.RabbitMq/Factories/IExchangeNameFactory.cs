namespace Messaging.RabbitMq
{
    public interface IExchangeNameFactory
    {
        string Build<T>();
    }
}