using System.Collections.Generic;
using System.Linq;
using AnotherLinq.Core;
using NUnit.Framework;

namespace AnotherLinq.Tests
{
    [TestFixture]
    public class MyCountTester
    {
        [Test]
        public void MyCountWhetherGetsNullAsSourceThrowsAnArgumentNullException()
        {
            Assert.That(() => ((IEnumerable<int>)null).MyCount(), Throws.ArgumentNullException.With.Property("ParamName").EqualTo("source"));
        }

        [Test]
        public void MyCountWhetherGetsNullAsPredicateThrowsAnArgumentNullException()
        {
            Assert.That(() => Enumerable.Empty<int>().MyCount(null), Throws.ArgumentNullException.With.Property("ParamName").EqualTo("predicate"));
        }

        [Test]
        public void MyCountGetsEmptySequenceReturns0()
        {
            Assert.That(Enumerable.Empty<int>().MyCount(), Is.EqualTo(0));
        }

        [Test]
        public void MyCountWithPredicateGetsEmptySequenceReturns0()
        {
            Assert.That(Enumerable.Empty<int>().MyCount(n => n > 0), Is.EqualTo(0));
        }

        [Test]
        public void MyCountGetsSequenceReturnsCountOfElementsInSequence()
        {
            Assert.That("Hello".MyCount(), Is.EqualTo(5));
        }

        [Test]
        public void MyCountWithPreduicateGetsSequenceReturnsCountOfElementsInSequenceWhichAreSatisfyThePredicate()
        {
            Assert.That("Hello".MyCount(c => c == 'l'), Is.EqualTo(2));
        }
    }
}