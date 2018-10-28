using System.Collections.Generic;
using System.Linq;
using AnotherLinq.Core;
using NUnit.Framework;

namespace AnotherLinq.Tests
{
    [TestFixture]
    public class MyToListTester
    {
        [Test]
        public void MyToListThrowsAnArgumentNullExceptionWhenSourceIsNull()
        {
            Assert.That(() => ((IEnumerable<int>)null).MyToList(), Throws.ArgumentNullException.With.Property("ParamName").EqualTo("source"));
        }

        [Test]
        public void MyToListReturnsListWithTypeExactlySameAsInputSequence()
        {
            Assert.That(Enumerable.Empty<int>().MyToList(), Is.TypeOf<List<int>>());
        }
    }
}