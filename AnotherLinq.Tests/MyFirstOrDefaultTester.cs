using System.Collections.Generic;
using System.Linq;
using AnotherLinq.Core;
using NUnit.Framework;

namespace AnotherLinq.Tests
{
    [TestFixture]
    public class MyFirstOrDefaultTester
    {
        [Test]
        public void MyFirstOrDefaultThrowsAnArgumentNullExceptionWhenSourceIsNull()
        {
            Assert.That(() => ((IEnumerable<int>)null).MyFirstOrDefault(), Throws.ArgumentNullException.With.Property("ParamName").EqualTo("source"));
        }

        [Test]
        public void MyFirstOrDefaultThrowsAnArgumentNullExceptionWhenPredicateIsNull()
        {
            Assert.That(() => Enumerable.Empty<int>().MyFirstOrDefault(null), Throws.ArgumentNullException.With.Property("ParamName").EqualTo("predicate"));
        }

        [Test]
        public void MyFirstOrDefaultReturnsDefaultIfSourceIsEmpty()
        {
            Assert.That(Enumerable.Empty<int>().MyFirstOrDefault(), Is.EqualTo(0));
        }

        [Test]
        public void MyFirstOrDefaultReturnsDefaultIfNeitherElementIsSatisfiesThePredicate()
        {
            Assert.That("hello".MyFirstOrDefault(c => c == 'a'), Is.EqualTo('\0'));
        }

        [Test]
        public void MyFirstOrDefaultReturnsFirstElementOfNotEmptySequence()
        {
            Assert.That("hello".MyFirstOrDefault(), Is.EqualTo('h'));
        }

        [Test]
        public void MyFirstOrDefaultReturnsFirstElementOfNotEmptySequenceWhichIsSatisfiedThePredicate()
        {
            Assert.That((new int[] { 9, 0, -1 }).MyFirstOrDefault(n => n <= 0), Is.EqualTo(0));
        }
    }
}
