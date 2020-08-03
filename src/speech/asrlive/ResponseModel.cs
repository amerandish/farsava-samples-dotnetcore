namespace asrlive
{
    using System;

    using Newtonsoft.Json;

    public partial class ResponseModel
    {
        [JsonProperty("transcriptionId")]
        public string TranscriptionId { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("inferenceTime")]
        public long InferenceTime { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("results")]
        public Result[] Results { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("transcript")]
        public string Transcript { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }

        [JsonProperty("words")]
        public Word[] Words { get; set; }
    }

    public partial class Word
    {
        [JsonProperty("startTime")]
        public double StartTime { get; set; }

        [JsonProperty("endTime")]
        public double EndTime { get; set; }

        [JsonProperty("word")]
        public string WordWord { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }
    }

    public partial class ResponseModel
    {
        public static ResponseModel FromJson(string json) => JsonConvert.DeserializeObject<ResponseModel>(json, asrlive.Converter.Settings);
    }
}
