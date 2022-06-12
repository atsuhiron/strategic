using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Game.Parsers
{
    public static class DictParser
    {
        public static bool TryGetCastedStruct<TResult, TMid>(string key, out TResult casted, Dictionary<string, object> dict, Func<TMid, TResult> converter)
            where TResult : struct
        {
            if (dict.ContainsKey(key) && dict[key] is TMid mid)
            {
                casted = converter(mid);
                return true;
            }

            casted = default;
            return false;
        }

        public static bool TryGetCastedStruct<TResult>(string key, out TResult casted, Dictionary<string, object> dict)
            where TResult : struct
        {
            return TryGetCastedStruct<TResult, TResult>(key, out casted, dict, x => x);
        }

        public static bool TryGetCastedClass<TResult, TMid>(string key, out TResult? casted, Dictionary<string, object> dict, Func<TMid, TResult> converter)
            where TResult : class
        {
            if (dict.ContainsKey(key) && dict[key] is TMid mid)
            {
                casted = converter(mid);
                return true;
            }

            casted = default;
            return false;
        }

        public static bool TryGetCastedClass<TResult>(string key, out TResult? casted, Dictionary<string, object> dict)
            where TResult : class
        {
            return TryGetCastedClass<TResult, TResult>(key, out casted, dict, x => x);
        }

        // 参考文献：https://yaspage.com/cs-json-to-dictionary/
        // JSON文字列をDictionary<string, dynamic>型に変換するメソッド
        public static Dictionary<string, dynamic?> ParseJson(string json)
        {
            // とりあえずJSON文字列をDictionary<string, JsonElement>型に変換
            var dic = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);
            if (dic == null)
            {
                return new Dictionary<string, dynamic?>();
            }

            // JsonElementから値を取り出してdynamic型に入れてDictionary<string, dynamic>型で返す
            return dic.Select(d => new { key = d.Key, value = ParseJsonElement(d.Value) })
                      .ToDictionary(a => a.key, a => a.value);
        }

        // JsonElementの型を調べて変換するメソッド
        private static dynamic? ParseJsonElement(JsonElement elem)
        {
            // データの種類によって値を取得する処理を変える
            return elem.ValueKind switch
            {
                JsonValueKind.String => elem.GetString(),
                JsonValueKind.Number => elem.GetDecimal(),
                JsonValueKind.False => false,
                JsonValueKind.True => true,
                JsonValueKind.Array => elem.EnumerateArray().Select(e => ParseJsonElement(e)).ToList(),
                JsonValueKind.Null => null,
                JsonValueKind.Object => ParseJson(elem.GetRawText()),
                _ => throw new NotSupportedException(),
            };
        }
    }
}
