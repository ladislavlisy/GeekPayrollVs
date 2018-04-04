using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Json
{
    using Legalist.Constants;
    using Libs;
    using Newtonsoft.Json;

    public class WorkEmployTermsConverter : JsonConverter<WorkEmployTerms>
    {
        public override void WriteJson(JsonWriter writer, WorkEmployTerms value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override WorkEmployTerms ReadJson(JsonReader reader, Type objectType, WorkEmployTerms existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string symbolName = (string)reader.Value;

            return symbolName.ToEnum<WorkEmployTerms>();
        }
    }

    public class WorkPositionTypeConverter : JsonConverter<WorkPositionType>
    {
        public override void WriteJson(JsonWriter writer, WorkPositionType value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override WorkPositionType ReadJson(JsonReader reader, Type objectType, WorkPositionType existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string symbolName = (string)reader.Value;

            return symbolName.ToEnum<WorkPositionType>();
        }
    }

    public class WorkScheduleTypeConverter : JsonConverter<WorkScheduleType>
    {
        public override void WriteJson(JsonWriter writer, WorkScheduleType value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override WorkScheduleType ReadJson(JsonReader reader, Type objectType, WorkScheduleType existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string symbolName = (string)reader.Value;

            return symbolName.ToEnum<WorkScheduleType>();
        }
    }

}
