using System;
using System.Collections.Generic;
using System.Linq;

namespace WowPacketParser.Generators.Extensions
{
    internal static class LinqExtensions
    {
        public static void Deconstruct<L, R>(this IGrouping<L, R> grouping, out L left, out IEnumerable<R> right)
        {
            left = grouping.Key;
            right = grouping.AsEnumerable();
        }

        public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> keyValuePair, out TKey key, out TValue value)
        {
            key = keyValuePair.Key;
            value = keyValuePair.Value;
        }

        public static IEnumerable<(int Index, T Value)?> Indexed<T>(this IEnumerable<T> source)
        {
            var idx = 0;
            foreach (var item in source)
                yield return (idx++, item);
        }

        public static (IEnumerable<T>, IEnumerable<T>) PartitionBy<T>(this IEnumerable<T> source, Func<T, bool> predicate)
            => (source.Where(predicate), source.Where(predicate.Negate()));

        public static Func<T, bool> Negate<T>(this Func<T, bool> fn) => x => !fn(x);
    }
}
