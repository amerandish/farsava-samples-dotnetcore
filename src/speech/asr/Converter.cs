
namespace asr
{
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public static class Serialize
    {
        public static string ToJson(this RequestModel self) => JsonConvert.SerializeObject(self, asr.Converter.Settings);
        public static string ToJson(this ResponseModel self) => JsonConvert.SerializeObject(self, asr.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
