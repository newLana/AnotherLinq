﻿using System.Collections.Generic;
using System.Linq;
using AnotherLinq.Core;
using NUnit.Framework;

namespace AnotherLinq.Tests
{
    [TestFixture]
    public class MyDistinctTester
    {
        [Test]
        public void MyDistinctThrowsAnArgumentNullExceptionWhenSourceIsNull()
        {
            IEnumerable<int> source = null;
            Assert.That(() => source.MyDistinct(), Throws.ArgumentNullException.With.Property("ParamName").EqualTo("source"));
        }

        [Test]
        public void MyDistinctReturnsEmptySequenceWhenSourceIsEmpty()
        {
            Assert.That(Enumerable.Empty<int>().MyDistinct(), Is.Empty);
        }

        [Test]
        public void MyDistinctReturnsElementsOfSequenceWithoutRepeatedElements([Values(new int[] { 2, 3, 4, 3, 3, 1, 2 }, new int[] { 10, 2, 3, 4, 10, 34, 55, 66, 4, 88 })] int[] numbers)
        {
            var actual = numbers.MyDistinct();
            var expected = numbers.Distinct();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}