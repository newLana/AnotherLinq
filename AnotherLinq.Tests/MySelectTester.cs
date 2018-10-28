using System.Collections.Generic;
using System.Linq;
using AnotherLinq.Core;
using NUnit.Framework;

namespace AnotherLinq.Tests
{
    [TestFixture]
    public class MySelectTester
    {
        [Test]
        public void MySelectThrowsAnArgumentNullExcpetionWhenSourceIsNull()
        {
            Assert.That(() => ((IEnumerable<int>)null).MySelect(n => n * 2), Throws.ArgumentNullException.With.Property("ParamName").EqualTo("source"));
        }

        [Test]
        public void MySelectThrowsAnArgumentNullExceptionWhenSelectorIsNull()
        {
            Assert.That(() => Enumerable.Empty<int>().MySelect<int, object>(null), Throws.ArgumentNullException.With.Property("ParamName").EqualTo("selector"));
        }

        [Test]
        public void MySelectReturnsProjectionOnSourceElements()
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

            var actual = books.MyWhere(b => b.Author == "G. Orwell").MySelect(b => b.Name);
            var expected = books.Where(b => b.Author == "G. Orwell").Select(b => b.Name);
        }
    }
}