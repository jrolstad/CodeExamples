using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Data.Linq;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Examples.Core.Repositories;
using FizzWare.NBuilder;
using NUnit.Framework;
using System.Linq;
using RepositoryExamples.AmazonSimpleDb.Mappers;
using RepositoryExamples.AmazonSimpleDb.Queryable;

namespace RepositoryExamples.AmazonSimpleDb.Tests
{
    [TestFixture]
    public class Class1
    {
        public class TestEntity:IEntity
        {
            public string Id { get; set; }
        }
        [Test]
        public void TestMethodName()
        {
            // Arrange
            var q = new AmazonSimpleDbQueryable<TestEntity>(new AmazonSimpleDbQueryProvider<TestEntity>(new ExpressionMapper()));
            
            // Act
            var result = q.Where(a => a.Id == "foo");

            // Assert
            Assert.That(result.ToArray(), Is.Not.Null);
            Assert.That(result.FirstOrDefault(), Is.Not.Null);
        }
    }
}
