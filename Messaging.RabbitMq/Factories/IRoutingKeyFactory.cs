namespace Messaging.RabbitMq
{
    public interface IRoutingKeyFactory
    {
        string Build<T>(); 
    }
}