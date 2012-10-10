using Amazon.SQS;
using Amazon.SQS.Model;
using Examples.Core.Messaging;

namespace Messaging.AmazonSqs
{
    public class MessageQueueDetailFactory : IMessageQueueDetailFactory
    {
        private readonly AmazonSQSClient _client;

        public MessageQueueDetailFactory(AmazonSQSClient client)
        {
            _client = client;
        }

        public MessageQueueDetail Build(string uri)
        {
            var request = new GetQueueAttributesRequest().WithQueueUrl(uri);

            var response = _client.GetQueueAttributes(request);

            if (response.IsSetGetQueueAttributesResult())
            {
                return new MessageQueueDetail
                    {
                        MessageCount = response.GetQueueAttributesResult.ApproximateNumberOfMessages,
                        Uri = uri,
                        Exists = true
                    };
            }

            return new MessageQueueDetail {Exists = false, Uri = uri};
        }

        public void Dispose()
        {
            // Nothing to see here.  Move along.
        }
    }
}