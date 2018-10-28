using System.Collections.Generic;
using System.Linq;
using AnotherLinq.Core;
using NUnit.Framework;

namespace AnotherLinq.Tests
{
    [TestFixture]
    public class MyLastOrDefaultTester
    {
        [Test]
        public void MyLastOrDefaultThrowsAnArgumentNullExceptionWhenSourceIsNull()
        {
            Assert.That(() => ((IEnumerable<int>)null).MyLastOrDefault(), Throws.ArgumentNullException.With.Property("ParamName").EqualTo("source"));
        }

        [Test]
        public void MyLastOrDefaultThrowsAnArgumentNullExceptionWhenPredicateIsNull()
        {
            Assert.That(() => Enumerable.Empty<int>().MyLastOrDefault(null), Throws.ArgumentNullException.With.Property("ParamName").EqualTo("predicate"));
        }

        [Test]
        public void MyLastOrDefaultReturnsDefaultIfSourceIsEmpty()
        {
            Assert.That(Enumerable.Empty<int>().MyLastOrDefault(), Is.EqualTo(0));
        }

        [Test]
        public void MyLastOrDefaultReturnsDefaultIfNeitherElementIsSatisfiesThePredicate()
        {
            Assert.That("hello".MyLastOrDefault(c => c == 'a'), Is.EqualTo('\0'));
        }

        [Test]
        public void MyLastOrDefaultReturnsFirstElementOfNotEmptySequence()
        {
            Assert.That("hello".MyLastOrDefault(), Is.EqualTo('o'));
        }

        [Test]
        public void MyLastOrDefaultReturnsFirstElementOfNotEmptySequenceWhichIsSatisfiedThePredicate()
        {
            Assert.That((new int[] { 9, 0, -1 }).MyLastOrDefault(n => n <= 0), Is.EqualTo(-1));
        }
    }
}