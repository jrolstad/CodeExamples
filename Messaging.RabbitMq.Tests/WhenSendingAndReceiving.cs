﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Messaging.RabbitMq.Factories;
using Messaging.RabbitMq.Formatters;
using Messaging.RabbitMq.Tests.Messages;
using NUnit.Framework;
using RabbitMQ.Client;

namespace Messaging.RabbitMq.Tests
{
    [TestFixture]
    public class WhenSendingAndReceiving
    {
        [Test]
        public void When_sending_a_message_it_can_be_received()
        {
            // Arrange
            var uri = @"amqp://devq:devq@sea-2600-53:5672/Dev_JoshR";

            var message = new TestMessage { Identifier = Guid.NewGuid().ToString(), Description = "something", SentAt = DateTime.Now };
            var receivedMessages = new List<TestMessage>();

            var queueConfiguration = new QueueConfiguration { IsQueueDurable = true, IsQueueExclusive = false, SupportsAutoDelete = false };
            var exchangeConfiguration = new ExchangeConfiguration { ExchangeType = ExchangeType.Direct, IsExchangeDurable = true };

            var receiver = new RabbitMqMessageSubscriber<TestMessage>(uri, new ClassTypeNameExchangeNameFactory(), new ClassTypeQueueNameFactory(), new EmptyRoutingKeyFactory(), new JsonMessageFormatter(), queueConfiguration);
            receiver.Subscribe(s =>
                {
                    receivedMessages.Add(s.Message);
                    s.Accept();
                });

            var sender = new RabbitMqMessenger(uri, new ClassTypeNameExchangeNameFactory(), new EmptyRoutingKeyFactory(), new JsonMessageFormatter(),exchangeConfiguration);

            // Act
            sender.Send(message);

            Thread.Sleep(5000);

            // Assert
            Assert.That(receivedMessages, Is.Not.Empty);
        }

        [Test]
        public void When_rejecting_a_message_it_is_removed_from_the_queue()
        {
            // Arrange
            var uri = @"amqp://devq:devq@sea-2600-53:5672/Dev_JoshR";

            var message = new TestMessage { Identifier = Guid.NewGuid().ToString(), Description = "something", SentAt = DateTime.Now };
            var receivedMessages = new List<TestMessage>();

            var queueConfiguration = new QueueConfiguration { IsQueueDurable = true, IsQueueExclusive = false, SupportsAutoDelete = false };
            var exchangeConfiguration = new ExchangeConfiguration { ExchangeType = ExchangeType.Direct, IsExchangeDurable = true };

            var receiver = new RabbitMqMessageSubscriber<TestMessage>(uri, new ClassTypeNameExchangeNameFactory(), new ClassTypeQueueNameFactory(), new EmptyRoutingKeyFactory(), new JsonMessageFormatter(), queueConfiguration);
            receiver.Subscribe(s =>
            {
                receivedMessages.Add(s.Message);
                s.Reject();
            });

            var sender = new RabbitMqMessenger(uri, new ClassTypeNameExchangeNameFactory(), new EmptyRoutingKeyFactory(), new JsonMessageFormatter(), exchangeConfiguration);

            // Act
            sender.Send(message);

            Thread.Sleep(5000);

            // Assert
            Assert.That(receivedMessages, Is.Not.Empty);
        }
    }
}
