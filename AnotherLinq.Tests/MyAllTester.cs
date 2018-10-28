using System.Collections.Generic;
using System.Collections;
using System.Linq;
using NUnit.Framework;
using AnotherLinq.Core;

namespace AnotherLinq.Tests
{
    [TestFixture]
    public class MyAllPrimitiveTypesTester
    {
        [Test]
        public void MyAllWhetherGetsNullAsSourceThrowsAnArgumentNullException()
        {
            Assert.That(() => ((IEnumerable<int>)null).MyAll(n => n > 0), Throws.ArgumentNullException.With.Property("ParamName").EqualTo("source"));
        }

        [Test]
        public void MyAllWhetherGetsNullAsPredicateThrowsAnArgumentNullException()
        {
            Assert.That(() => Enumerable.Empty<int>().MyAll(null), Throws.ArgumentNullException.With.Property("ParamName").EqualTo("predicate"));
        }

        [Test]
        public void MyAllDeterminesWhenAllIntsAreNonNegative([Values(new int[] { 0, 1, 2, 3 }, new int[] { 0, -1, -3 })] IEnumerable<int> nums)
        {
            var actual = nums.MyAll(n => n >= 0);
            var expected = nums.All(n => n >= 0);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void MyAllDeterminesWhenMyAllStringssAreNullOrAreEmpty([Values(new string[] { "", null, null, "" }, new string[] { "", null, "Hello", "", "World", " " })] IEnumerable<string> strings)
        {
            var actual = strings.MyAll(s => string.IsNullOrEmpty(s));
            var expected = strings.All(s => string.IsNullOrEmpty(s));

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void MyAllDeterminesWhenAllElementsAreNull([Values(new object[] { null, null, null, null }, new object[] { null, null, null, "" })] IEnumerable<object> objects)
        {
            bool actual = objects.MyAll(o => o == null);
            bool expected = objects.All(o => o == null);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    [TestFixtureSource(typeof(FixtureData), "FixtureParams")]
    public class MyAllNonPrimitiveTypesTester
    {
        private Book[] books;

        public MyAllNonPrimitiveTypesTester(Book book1, Book book2, Book book3)
        {
            this.books = new Book[] { book1, book2, book3 };
        }

        [Test]
        public void MyAllDeterminesWhenAllBooksAreFromOneAuthor()
        {
            var actual = books.MyAll(s => s.Author == "G. Orwell");
            var expected = books.All(s => s.Author == "G. Orwell");

            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    public class FixtureData
    {
        public static IEnumerable FixtureParams
        {
            get
            {
                yield return new TestFixtureData(
                    new Book { Name = "Animal Farm", Author = "G. Orwell" },
                    new Book { Name = "1984", Author = "G. Orwell" },
                    new Book { Name = " Coming Up for Air", Author = "G. Orwell" }
                );

                yield return new TestFixtureData(
                    new Book { Name = "Animal Farm", Author = "G. Orwell" },
                    new Book { Name = "1984", Author = "G. Orwell" },
                    new Book { Name = "This Side of Paradise", Author = "F. Fitzgerald" }
                );
            }
        }
    }
}
