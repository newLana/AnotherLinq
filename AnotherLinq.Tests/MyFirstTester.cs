using System;
using System.Collections.Generic;
using System.Linq;
using AnotherLinq.Core;
using NUnit.Framework;

namespace AnotherLinq.Tests
{
    [TestFixture]
    public class MyFirstTester
    {
        [Test]
        public void MyFirstThrowsArgumentNullExceptionForNullSource()
        {
            Assert.That(() => ((IEnumerable<int>)null).MyFirst(), Throws.ArgumentNullException.With.Property("ParamName").EqualTo("source"));
        }

        [Test]
        public void MyFirstThrowsArgumentNullExceptionForNullPredicate()
        {
            Assert.That(() => Enumerable.Empty<int>().MyFirst(null), Throws.ArgumentNullException.With.Property("ParamName").EqualTo("predicate"));
        }

        [Test]
        public void MyFirstThrowsInvalidOperationExceptionForEmptySource()
        {
            Assert.That(() => Enumerable.Empty<int>().MyFirst(), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void MyFirstThrowsInvalidOperationExceptionIfNeitherElementSatisfiesThePredicate()
        {
            Assert.That(() => "Hello".MyFirst(c => c == 'a'), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void MyFirstReturnsFirstElementOfSequence()
        {
            Assert.That("hello".MyFirst(), Is.EqualTo('h'));
        }

        [Test]
        public void MyFirstReturnsFirstElementOfSequenceWhichIsSatisfieidThePredicate()
        {
            IEnumerable<int> nums = new int[] { -1, 2, -3, 0 };

            Assert.That(nums.MyFirst(n => n <= 0), Is.EqualTo(-1));
        }
    }
}