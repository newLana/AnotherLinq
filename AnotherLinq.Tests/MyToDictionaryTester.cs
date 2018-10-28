using System.Collections.Generic;
using System.Linq;
using AnotherLinq.Core;
using NUnit.Framework;

namespace AnotherLinq.Tests
{
    [TestFixture]
    public class MyToDictionaryTester
    {
        [Test]
        public void MyToDictionaryThrowsAnArgumentNullExceptionWhenSourceIsNull()
        {
            Assert.That(() => ((IEnumerable<Book>)null).MyToDictionary(s => s.Id), Throws.ArgumentNullException.With.Property("ParamName").EqualTo("source"));
        }

        [Test]
        public void MyToDictionaryThrowsAnArgumentNullExceptionWhenKeySelectorIsNull()
        {
            Assert.That(() => Enumerable.Empty<int>().MyToDictionary<int, bool>(null), Throws.ArgumentNullException.With.Property("ParamName").EqualTo("keySelector"));
        }

        [Test]
        public void MyToDictionaryThrowsAnArgumentNullExceptionWhenKeyIsNull()
        {
            IEnumerable<string> strs = new string[] { "Select", "Allows", "Yeah" };
            Assert.That(() => strs.MyToDictionary<string, string>(s => null), Throws.ArgumentNullException);
        }

        [Test]
        public void MyToDictionaryThrowsAnArgumentExceptionWhenKeyIsDuplicate()
        {
            IEnumerable<string> strs = new string[] { "Select", "Allows", "Yeah" };

            Assert.That(() => strs.MyToDictionary(s => s.Length), Throws.ArgumentException);
        }

        [Test]
        public void MyToDictionaryThrowsAnArgumentNullExceptionWhenElementSelectorIsNull()
        {
            IEnumerable<string> strs = new string[] { "Select", "Allows", "Yeah" };

            Assert.That(() => strs.MyToDictionary<string, int, object>(s => s.Length, null), Throws.ArgumentNullException);
        }

        [Test]
        public void MyToDictionaryReturnsDictionaryWithValuesAndKeySelectors()
        {
            IEnumerable<Book> books = new Book[]
            {
                new Book { Id = 1, Name = "Animal Farm", Author = "G. Orwell" },
                new Book { Id = 2, Name = "1984", Author = "G. Orwell" },
                new Book { Id = 3, Name = " Coming Up for Air", Author = "G. Orwell" }
            };

            var actual = books.MyToDictionary(b => b.Id);
            var expected = books.ToDictionary(b => b.Id);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void MyToDictionaryReturnsDictionaryWithKeySelectorsAndValueSelector()
        {
            IEnumerable<Book> books = new Book[]
            {
                new Book { Id = 1, Name = "Animal Farm", Author = "G. Orwell" },
                new Book { Id = 2, Name = "1984", Author = "G. Orwell" },
                new Book { Id = 3, Name = " Coming Up for Air", Author = "G. Orwell" }
            };

            var actual = books.MyToDictionary(b => b.Id, b => b.Name);
            var expected = books.ToDictionary(b => b.Id, b => b.Name);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}