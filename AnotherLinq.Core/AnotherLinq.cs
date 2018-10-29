using System;
using System.Collections.Generic;
using System.Linq;

namespace AnotherLinq.Core
{
    public static class AnotherLinq
    {
        public static bool MyAll<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            foreach (var item in source)
            {
                if (!predicate(item))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool MyAny<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return Any(source, null);
        }

        public static bool MyAny<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return Any(source, predicate);
        }

        private static bool Any<T>(IEnumerable<T> source, Predicate<T> predicate)
        {
            foreach (T item in source)
            {
                if (predicate == null || predicate(item))
                {
                    return true;
                }
            }
            return false;
        }

        public static int MyCount<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return Count(source, null);
        }

        public static int MyCount<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return Count(source, predicate);
        }

        private static int Count<T>(IEnumerable<T> source, Predicate<T> predicate)
        {
            int count = 0;
            foreach (var item in source)
            {
                if (predicate == null || predicate(item))
                {
                    count++;
                }
            }
            return count;
        }

        public static T MyFirst<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return First(source, null);
        }

        public static T MyFirst<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return First(source, predicate);
        }

        private static T First<T>(IEnumerable<T> source, Predicate<T> predicate)
        {
            foreach (var item in source)
            {
                if (predicate == null || predicate(item))
                {
                    return item;
                }
            }

            throw new InvalidOperationException();
        }

        public static T MyFirstOrDefault<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return FirstOrDefault(source, null);
        }

        public static T MyFirstOrDefault<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return FirstOrDefault(source, predicate);
        }

        private static T FirstOrDefault<T>(IEnumerable<T> source, Predicate<T> predicate)
        {
            foreach (var item in source)
            {
                if (predicate == null || predicate(item))
                {
                    return item;
                }
            }

            return default(T);
        }

        public static IEnumerable<IGrouping<TKey, TSource>> MyGroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (keySelector == null)
            {
                throw new ArgumentNullException(nameof(keySelector));
            }

            return GroupBy(source, keySelector);
        }

        private static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            List<TSource> srcList = source.MyToList<TSource>();

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

        public static T MyLast<T>(this IEnumerable<T> source)
        {
            T last = source.MyFirst();

            foreach (T item in source)
            {
                last = item;
            }

            return last;
        }

        public static T MyLast<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            T last = source.MyFirst(predicate);

            foreach (T item in source)
            {
                if (predicate(item))
                {
                    last = item;
                }
            }

            return last;
        }

        public static T MyLastOrDefault<T>(this IEnumerable<T> source)
        {
            T last = source.MyFirstOrDefault();
            foreach (T item in source)
            {
                last = item;
            }

            return last;
        }

        public static T MyLastOrDefault<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            T last = source.MyFirstOrDefault(predicate);

            foreach (T item in source)
            {
                if (predicate(item))
                {
                    last = item;
                }
            }

            return last;
        }

        public static ILookup<TKey, TSource> MyToLookup<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (keySelector == null)
            {
                throw new ArgumentNullException(nameof(keySelector));
            }

            return new MyLookup<TKey, TSource>(source, keySelector);
        }

        public static IEnumerable<T> MyDistinct<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return Distinct(source);
        }

        private static IEnumerable<T> Distinct<T>(IEnumerable<T> source)
        {
            List<T> l = source.MyToList();

            for (int j = 0; j < l.Count; j++)
            {
                for (int i = j + 1; i < l.Count; i++)
                {
                    if (l[i].Equals(l[j]))
                    {
                        l.RemoveAt(i);
                    }
                }
                yield return l[j];
            }
        }

        public static T[] MyToArray<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            T[] array = new T[source.MyCount()];
            int i = 0;

            foreach (var item in source)
            {
                array[i++] = item;
            }

            return array;
        }

        public static List<T> MyToList<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return new List<T>(source);
        }

        public static Dictionary<TKey, TSource> MyToDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (keySelector == null)
            {
                throw new ArgumentNullException(nameof(keySelector));
            }

            Dictionary<TKey, TSource> dictionary = new Dictionary<TKey, TSource>();
            TKey key;

            foreach (var item in source)
            {
                if ((key = keySelector(item)) == null)
                {
                    throw new ArgumentNullException();
                }

                if (dictionary.ContainsKey(key))
                {
                    throw new ArgumentException();
                }

                dictionary.Add(key, item);
            }

            return dictionary;
        }

        public static Dictionary<TKey, TElement> MyToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (keySelector == null)
            {
                throw new ArgumentNullException(nameof(keySelector));
            }


            if (elementSelector == null)
            {
                throw new ArgumentNullException(nameof(elementSelector));
            }

            Dictionary<TKey, TElement> dictionary = new Dictionary<TKey, TElement>();
            TKey key;

            foreach (var item in source)
            {
                if ((key = keySelector(item)) == null)
                {
                    throw new ArgumentNullException();
                }

                if (dictionary.ContainsKey(key))
                {
                    throw new ArgumentException();
                }

                dictionary.Add(key, elementSelector(item));
            }

            return dictionary;
        }

        public static IEnumerable<TResult> MySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            return Select(source, selector);
        }

        private static IEnumerable<TResult> Select<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (var item in source)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return Where(source, predicate);
        }

        private static IEnumerable<T> Where<T>(IEnumerable<T> source, Predicate<T> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
}
