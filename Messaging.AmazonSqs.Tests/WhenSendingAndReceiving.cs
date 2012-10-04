﻿using System;
using System.Collections.Generic;
using System.Threading;
using Amazon.SQS;
using Amazon.SQS.Model;
using Messaging.AmazonSqs.Tests.Messages;
using NUnit.Framework;

namespace Messaging.AmazonSqs.Tests
{
    [TestFixture]
    public class WhenSendingAndReceiving
    {
        [Test]
        public void When_sending_a_message_it_can_be_received()
        {
            // Arrange
            var message = new TestMessage { Identifier = Guid.NewGuid().ToString(), Description = "something", SentAt = DateTime.Now };

            var receivedMessages = new List<TestMessage>();

            var client = new AmazonSQSClient("<access key here>", "<secrey key here>");
            var response = client.CreateQueue(new CreateQueueRequest().WithQueueName("testQueue"));
            var uri = response.CreateQueueResult.QueueUrl;

            var receiver = new AmazonSqsMessageSubscriber<TestMessage>(client,uri, new JsonMessageFormatter());
            receiver.Subscribe(s =>
                {
                    receivedMessages.Add(s.Message);
                    s.Accept();
                });

            var sender = new AmazonSqsMessenger(client, uri, new JsonMessageFormatter());

            // Act
            sender.Send(message);

            Thread.Sleep(5000);

            // Assert
            Assert.That(receivedMessages, Is.Not.Empty);
        }
    }
}