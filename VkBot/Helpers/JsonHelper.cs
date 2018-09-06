using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkBot.Helpers
{
    public static class JsonHelper
    {
        /// <summary>
        /// Сериализация словаря в объект JSON.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static string SerializeDictionary<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        {
            return JsonConvert.SerializeObject(dictionary, Formatting.Indented);
        }
    }
}