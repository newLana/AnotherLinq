using System.Collections.Generic;
using System.Linq;
using AnotherLinq.Core;
using NUnit.Framework;

namespace AnotherLinq.Tests
{
    [TestFixture]
    public class MyToArrayTester
    {
        [Test]
        public void MyToArrayThrowsAnArgumentNullExceptionWhenSourceIsNull()
        {
            Assert.That(() => ((IEnumerable<int>)null).MyToArray(), Throws.ArgumentNullException.With.Property("ParamName").EqualTo("source"));
        }

        [Test]
        public void MyToArrayReturnsAnArrayWithTypeOfInputSequence()
        {
            Assert.That(Enumerable.Empty<int>().ToArray(), Is.TypeOf<int[]>());
        }
    }
}
