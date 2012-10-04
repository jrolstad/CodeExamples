namespace Messaging.RabbitMq.Formatters
{
    public class EmptyRoutingKeyFactory:IRoutingKeyFactory
    {
        public string Build<T>()
        {
            return "";
        }
    }
}