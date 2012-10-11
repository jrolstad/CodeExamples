using System;
using System.Collections.Generic;
using System.Messaging;
using System.Threading;
using Messaging.MsMq.Formatters;
using Messaging.MsMq.Tests.Messages;
using NUnit.Framework;

namespace Messaging.MsMq.Tests
{
    [TestFixture]
    public class WhenSendingAndReceiving
    {
        [Test]
        public void When_sending_a_message_it_can_be_received()
        {
            // Arrange
            var uri = @"FormatName:DIRECT=OS:.\private$\testQueue";

            var message = new TestMessage { Identifier = Guid.NewGuid().ToString(), Description = "something", SentAt = DateTime.Now };

            var receivedMessages = new List<TestMessage>();

            var receiver = new MsMqMessageSubscriber<TestMessage>(uri, new JsonMessageFormatter(typeof(TestMessage)));
            receiver.Subscribe(s => receivedMessages.Add(s.Message));

            var sender = new MsMqMessenger(uri, new JsonMessageFormatter(typeof(TestMessage)));

            // Act
            sender.Send(message);
        
            Thread.Sleep(5000);

            // Assert
            Assert.That(receivedMessages,Is.Not.Empty);
        }
    }
}