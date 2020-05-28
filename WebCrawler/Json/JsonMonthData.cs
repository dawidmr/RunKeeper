using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Globalization;
using System.Text.Json.Serialization;

namespace WebCrawler
{
    public class JsonMonthData
    {
        [JsonPropertyName("month")]
        public string Month { get; set; }

        [JsonPropertyName("distance")]
        public string Distance { get; set; }

        [JsonPropertyName("dayOfMonth")]
        public string DayOfMonth { get; set; }

        [JsonPropertyName("year")]
        public string Year { get; set; }

        [JsonPropertyName("activity_id")]
        public long ActivityId { get; set; }

        [JsonPropertyName("distanceUnits")]
        public string DistanceUnits { get; set; }

        [JsonPropertyName("mainText")]
        public string MainText { get; set; }

        [JsonPropertyName("monthNum")]
        public string MonthNum { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("live")]
        public bool Live { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("elapsedTime")]
        public string ElapsedTime { get; set; }
    }
}
