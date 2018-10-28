using System.Collections.Generic;
using System.Linq;
using AnotherLinq.Core;
using NUnit.Framework;

namespace AnotherLinq.Tests
{
    [TestFixture]
    public class MyToLookupTester
    {
        [Test]
        public void MyToLookupThrowsAnArgumentNullExceptionWhenSourceIsNull()
        {
            Assert.That(() => ((IEnumerable<string>)null).MyToLookup(s => s.Length), Throws.ArgumentNullException.With.Property("ParamName").EqualTo("source"));
        }

        [Test]
        public void MyToLookupThrowsAnArgumentNullExceptionWhenKeySelectorIsNull()
        {
            Assert.That(() => Enumerable.Empty<int>().MyToLookup<int, object>(null), Throws.ArgumentNullException.With.Property("ParamName").EqualTo("keySelector"));
        }

        [Test]
        public void MyToLookupReturnsILookupInstance()
        {
            string[] input = { "Select", "Where", "OrderBy", "GroupBy" };

            var actual = input.MyToLookup(i => i.Length);
            var expected = input.ToLookup(i => i.Length);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
