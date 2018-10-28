using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AnotherLinq.Core
{
    internal class MyGrouping<TKey, TSource> : IGrouping<TKey, TSource>
    {
        public MyGrouping(TKey key, IEnumerable<TSource> elems)
        {
            elements = elems;
            this.Key = key;
        }

        private IEnumerable<TSource> elements;

        public TKey Key { get; }

        public IEnumerator<TSource> GetEnumerator()
        {
            return elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
