using System;
using System.Collections.Generic;
using System.Linq;
using AnotherLinq.Core;
using NUnit.Framework;

namespace AnotherLinq.Tests
{
    [TestFixture]
    public class MyWhereTester
    {
        [Test]
        public void MyWhereThrowsAnArgumentNullExceptionWhenPredicateIsNull()
        {
            IEnumerable<int> actual = Enumerable.Empty<int>();

            Assert.That(() => actual.MyWhere(null), Throws.ArgumentNullException
                .With.Property("ParamName").EqualTo("predicate"));
        }

        [Test]
        public void MyWhereThrowsAnArgumentNullExceptionWhenSourceIsNull()
        {
            IEnumerable<int> actual = null;

            Assert.That(() => actual.MyWhere(v => v > 0), Throws.ArgumentNullException
                .With.Property("ParamName").EqualTo("source"));
        }

        [Test]
        public void MyWhereFiltersASequenceOfIntValuesByNonNegative()
        {
            var values = new int[] { -10, -3, -1, 100, 15, -7, -12 };

            IEnumerable<int> actual = values.Where(v => v >= 0);
            IEnumerable<int> expected = Enumerable.Where(values, v => v >= 0);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, Repeat(20)]
        public void MyWhereFiltersASequenceOfRandomIntValuesByNonNegative()
        {
            var values = new int[10];
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                values[i] = random.Next(-15, 20);
            }

            IEnumerable<int> actual = values.Where(v => v >= 0);
            IEnumerable<int> expected = Enumerable.Where(values, v => v >= 0);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void MyWhereFiltersASequenceOfStringValuesByNull()
        {
            string[] values = new string[] { null, null, null };

            IEnumerable<string> actual = values.Where(v => v == null);

            Assert.That(actual, Has.Exactly(3).Items.EqualTo(null));
        }

        [Test]
        public void MyWhereFiltersASequenceOfStringValuesByNotNull()
        {
            string[] values = new string[] { null, null, null };

            IEnumerable<string> actual = values.Where(v => v != null);

            Assert.That(actual, Is.Empty);
        }

        [Test]
        public void MyWhereFiltersASequenceOfCustomObjectsByAuthor([Values("G. Orwell", "F. Fitzgerald", "H. Mellville")] string author)
        {
            IEnumerable<Book> books = new List<Book>
            {
                new Book{Name = "Animal Farm", Author = "G. Orwell"},
                new Book{Name = "1984", Author = "G. Orwell"},
                new Book{Name = " Coming Up for Air", Author = "G. Orwell"},
                new Book{Name = "Moby-Dick", Author = "H. Mellville"},
                new Book{Name = "The Great Gatsby", Author = "F. Fitzgerald"},
                new Book{Name = "This Side of Paradise", Author = "F. Fitzgerald"}
            };

            IEnumerable<Book> actual = books.Where(b => b.Author == author);
            IEnumerable<Book> expected = Enumerable.Where(books, b => b.Author == author);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}