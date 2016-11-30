namespace FreightHepler
{
    using System;
    using System.Collections.Generic;

    public class DictionaryUtil
    {
        public static void Add<TKey, TValue>(Dictionary<TKey, TValue> dict, TKey gparam_0, TValue value)
        {
            if (dict.ContainsKey(gparam_0))
            {
                dict[gparam_0] = value;
            }
            else
            {
                dict.Add(gparam_0, value);
            }
        }

        public static TValue Get<TKey, TValue>(Dictionary<TKey, TValue> dict, TKey gparam_0)
        {
            if (dict.ContainsKey(gparam_0))
            {
                return dict[gparam_0];
            }
            return default(TValue);
        }
    }
}

