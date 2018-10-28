using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherLinq.Core
{
    internal class MyLookup<TKey, TSource> : ILookup<TKey, TSource>
    {
        public IEnumerable<TSource> this[TKey key] => elements.MyFirstOrDefault(e => e.Key.Equals(key));

        public MyLookup(IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            elements = source.MyGroupBy(s => keySelector(s));
        }

        private IEnumerable<IGrouping<TKey, TSource>> elements;

        public int Count => elements.MyCount();

        public bool Contains(TKey key)
        {
            return elements.MyAny(e => e.Key.Equals(key));
        }

        public IEnumerator<IGrouping<TKey, TSource>> GetEnumerator()
        {
            return elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
