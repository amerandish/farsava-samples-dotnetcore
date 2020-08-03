namespace health
{

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class HealthModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public partial class HealthModel
    {
        public static HealthModel FromJson(string json) => JsonConvert.DeserializeObject<HealthModel>(json, health.Converter.Settings);
    }
}
