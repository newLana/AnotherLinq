using System;
using System.Collections.Generic;
using System.Linq;
using AnotherLinq.Core;
using NUnit.Framework;

namespace AnotherLinq.Tests
{
    [TestFixture]
    public class MyLastTester
    {
        [Test]
        public void MyLastThrowsArgumentNullExceptionForNullSource()
        {
            Assert.That(() => ((IEnumerable<int>)null).MyLast(), Throws.ArgumentNullException.With.Property("ParamName").EqualTo("source"));
        }

        [Test]
        public void MyLastThrowsArgumentNullExceptionForNullPredicate()
        {
            Assert.That(() => Enumerable.Empty<int>().MyLast(null), Throws.ArgumentNullException.With.Property("ParamName").EqualTo("predicate"));
        }

        [Test]
        public void MyLastThrowsInvalidOperationExceptionForEmptySource()
        {
            Assert.That(() => Enumerable.Empty<int>().MyLast(), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void MyLastThrowsInvalidOperationExceptionIfNeitherElementSatisfiesThePredicate()
        {
            Assert.That(() => "Hello".MyLast(c => c == 'a'), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void MyLastReturnsLastElementOfSequence()
        {
            Assert.That("hello".MyLast(), Is.EqualTo('o'));
        }

        [Test]
        public void MyLastReturnsLastElementOfSequenceWhichIsSatisfieidThePredicate()
        {
            IEnumerable<int> nums = new int[] { -1, 2, -3, 0 };

            Assert.That(nums.MyLast(n => n <= 0), Is.EqualTo(0));
        }
    }
}