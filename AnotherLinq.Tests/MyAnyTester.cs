using System.Collections.Generic;
using System.Linq;
using AnotherLinq.Core;
using NUnit.Framework;

namespace AnotherLinq.Tests
{
    [TestFixture]
    public class MyAnyTester
    {
        [Test]
        public void MyAnyWithoutPredicateWhetherGetsNullAsSourceThrowsAnArgumentNullException()
        {
            Assert.That(() => ((IEnumerable<int>)null).MyAny(), Throws.ArgumentNullException.With.Property("ParamName").EqualTo("source"));
        }

        [Test]
        public void MyAnyWithPredicateWhetherGetsNullAsSourceThrowsAnArgumentNullException()
        {
            Assert.That(() => ((IEnumerable<int>)null).MyAny(), Throws.ArgumentNullException.With.Property("ParamName").EqualTo("source"));
        }

        [Test]
        public void MyAnyWithPredicateWhetherGetsNullAsPredicateThrowsAnArgumentNullException()
        {
            Assert.That(() => Enumerable.Empty<string>().MyAny(null), Throws.ArgumentNullException.With.Property("ParamName").EqualTo("predicate"));
        }

        [Test]
        public void MyAnyDeterminesWhetherASequenceContainsAnyElement()
        {
            IEnumerable<object> objects = new List<object>
            {
                new object(),
                new object(),
                null,
                new object()
            };

            bool actual = objects.MyAny();
            Assert.That(actual, Is.True);
        }

        [Test]
        public void MyAnyDeterminesWhetherASequenceContainsNothing()
        {
            IEnumerable<int> objects = Enumerable.Empty<int>();

            bool actual = objects.MyAny();
            Assert.That(actual, Is.False);
        }

        [Test]
        public void MyAnyDeterminesWhetherASequenceContainsAnyNonNegative([Values(
            new int[] { -10, -3, -1, 100, 15, -7, -12 },
            new int[]{-1, 8}, new int[]{ -2, -1})] IEnumerable<int> nums)
        {
            bool actual = nums.MyAny(v => v >= 0);
            bool expected = nums.Any(v => v >= 0);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void MyAnyDeterminesWhetherASequenceContainsBookWithSetedAuthor([Values("G. Orwell", "F. Fitzgerald", "H. Mellville")] string author)
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

            bool actual = books.MyAny(b => b.Author == author);
            bool expected = books.Any(b => b.Author == author);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}