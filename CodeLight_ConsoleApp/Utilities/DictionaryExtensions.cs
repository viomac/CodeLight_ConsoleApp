using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeLight_ConsoleApp
{
    public static class DictionaryExtensions
    {
        public static void AddItem<TKey, TValue>(this IDictionary<TKey, List<TValue>> dict, TKey key, TValue value)
        {
            if (!dict.ContainsKey(key))
                dict.Add(key, new List<TValue>());

            dict[key].Add(value);
        }


    }
}