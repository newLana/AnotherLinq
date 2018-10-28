using System.Collections.Generic;
using System.Linq;
using AnotherLinq.Core;
using NUnit.Framework;

namespace AnotherLinq.Tests
{
    [TestFixture]
    public class MyGroupByTester
    {
        [Test]
        public void MyGroupByThrowsAnArgumentNullExceptionIfSourceIsNull()
        {
            Assert.That(() => ((IEnumerable<string>)null).MyGroupBy(s => s.Length), Throws.ArgumentNullException.With.Property("ParamName").EqualTo("source"));
        }

        [Test]
        public void MyGroupByThrowsAnAgumentNullExceptionIfKeySelectorIsNull()
        {
            IEnumerable<Book> books = new Book[]
            {
                new Book{Name = "Animal Farm", Author = "G. Orwell"},
                new Book{Name = "1984", Author = "G. Orwell"},
                new Book{Name = " Coming Up for Air", Author = "G. Orwell"},
                new Book{Name = "Moby-Dick", Author = "H. Mellville"},
                new Book{Name = "The Great Gatsby", Author = "F. Fitzgerald"},
                new Book{Name = "This Side of Paradise", Author = "F. Fitzgerald"}
            };

            Assert.That(() => books.MyGroupBy<Book, object>(null), Throws.ArgumentNullException.With.Property("ParamName").EqualTo("keySelector"));
        }

        [Test]
        public void MyGroupByGroupingSourceElementsByKeySelector()
        {
            IEnumerable<Book> books = new Book[]
            {
                new Book{Name = "Animal Farm", Author = "G. Orwell"},
                new Book{Name = "1984", Author = "G. Orwell"},
                new Book{Name = " Coming Up for Air", Author = "G. Orwell"},
                new Book{Name = "Moby-Dick", Author = "H. Mellville"},
                new Book{Name = "The Great Gatsby", Author = "F. Fitzgerald"},
                new Book{Name = "This Side of Paradise", Author = "F. Fitzgerald"}
            };

            var actual = books.MyGroupBy(b => b.Author);
            var expected = books.GroupBy(b => b.Author);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}