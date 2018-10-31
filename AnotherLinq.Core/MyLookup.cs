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
            elements = GetElements(source, keySelector);
        }

        private IEnumerable<IGrouping<TKey, TSource>> GetElements(IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            List<TSource> srcList = source.MyToList();

            for (int j = 0; j < srcList.Count - 1; j++)
            {
                var set = new List<TSource>();
                set.Add(srcList[j]);
                var key = keySelector(srcList[j]);
                for (int i = j + 1; i < srcList.Count; i++)
                {
                    if (keySelector(srcList[i]).Equals(key))
                    {
                        set.Add(srcList[i]);
                        srcList.RemoveAt(i--);
                    }
                }
                yield return new MyGrouping<TKey, TSource>(key, set);
            }
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
