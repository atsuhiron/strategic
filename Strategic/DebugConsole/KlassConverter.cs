using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DebugConsole
{
    public class KlassConverter : JsonConverter<IKlass>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(IKlass).IsAssignableFrom(typeToConvert);
        }

        public override IKlass? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var tt = reader.TokenType;
            return new Klass1("fake", -1);
        }

        public override void Write(Utf8JsonWriter writer, IKlass value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }

    public static class JsonToDict
    {
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
