using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ElementsLib.Module.Json
{
    using MarkCode = Module.Codes.ArticleCzCode;

    using Codes;
    using Interfaces.Elements;
    using Newtonsoft.Json.Converters;

    public class ArticleJsonConverter<T>  : JsonConverter<T>  
        where T : IArticleSource, new()
    {
        public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
        {
            var jsonEmployeeTermConverter = new WorkEmployeeTermConverter();
            var jsonPositionTypeConverter = new WorkPositionTypeConverter();
            var jsonDateTimeCoverter = new IsoDateTimeConverter() { DateTimeFormat = "d.M.yyyy" };

            JsonSerializer propertySerializer = new JsonSerializer();
            propertySerializer.Converters.Add(jsonEmployeeTermConverter);
            propertySerializer.Converters.Add(jsonPositionTypeConverter);
            propertySerializer.Converters.Add(jsonDateTimeCoverter);

            JToken t = JToken.FromObject(value, propertySerializer);

            JObject o = (JObject)t;

            MarkCode articleSymbol = ArticleCodeAdapter.CreateEnum(value.Code());

            JValue codeValue = (JValue)articleSymbol.GetSymbol();

            o.AddFirst(new JProperty("Code", codeValue));

            o.WriteTo(writer);
        }

 
        public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            T articleType = new T();     

            if (reader.TokenType != JsonToken.Null)
            {
                if (reader.TokenType == JsonToken.StartArray)
                {
                //    JToken token = JToken.Load(reader);
                //    List<string> items = token.ToObject<List<string>>();
                //    myCustomType = new MyCustomType(items);
                //}
                //else
                //{
                //    JValue jValue = new JValue(reader.Value);
                //    switch (reader.TokenType)
                //    {
                //        case JsonToken.String:
                //            myCustomType = new MyCustomType((string)jValue);
                //            break;
                //        case JsonToken.Date:
                //            myCustomType = new MyCustomType((DateTime)jValue);
                //            break;
                //        case JsonToken.Boolean:
                //            myCustomType = new MyCustomType((bool)jValue);
                //            break;
                //        case JsonToken.Integer:
                //            int i = (int)jValue;
                //            myCustomType = new MyCustomType(i);
                //            break;
                //        default:
                //            Console.WriteLine("Default case");
                //            Console.WriteLine(reader.TokenType.ToString());
                //            break;
                //    }
                }
            }
            return articleType;
        }
    }
}
