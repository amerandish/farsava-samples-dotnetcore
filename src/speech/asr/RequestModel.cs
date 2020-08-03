
namespace asr
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public partial class RequestModel
    {
        [JsonProperty("config")]
        public Config Config { get; set; }

        [JsonProperty("audio")]
        public Audio Audio { get; set; }
    }

    public partial class Audio
    {
        public Audio(string data){
            this.Data = data;
        }
        [JsonProperty("data")]
        public string Data { get; set; }
    }

    public partial class Config
    {
        public Config(string audioEncoding, long sampleRateHertz, string languageCode, long maxAlternatives, bool profanityFilter, string asrModel, string languageModel){
            this.AudioEncoding = audioEncoding;
            this.SampleRateHertz = sampleRateHertz;
            this.LanguageCode = languageCode;
            this.MaxAlternatives = maxAlternatives;
            this.ProfanityFilter = profanityFilter;
            this.AsrModel = asrModel;
            this.LanguageModel = languageModel;
        }
        [JsonProperty("audioEncoding")]
        public string AudioEncoding { get; set; }

        [JsonProperty("sampleRateHertz")]
        public long SampleRateHertz { get; set; }

        [JsonProperty("languageCode")]
        public string LanguageCode { get; set; }

        [JsonProperty("maxAlternatives")]
        public long MaxAlternatives { get; set; }

        [JsonProperty("profanityFilter")]
        public bool ProfanityFilter { get; set; }

        [JsonProperty("asrModel")]
        public string AsrModel { get; set; }

        [JsonProperty("languageModel")]
        public string LanguageModel { get; set; }
    }

    public partial class RequestModel
    {
        public static RequestModel FromJson(string json) => JsonConvert.DeserializeObject<RequestModel>(json, asr.Converter.Settings);
    }
}
