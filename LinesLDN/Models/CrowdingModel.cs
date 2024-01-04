using Newtonsoft.Json;
using static LinesLDN.Models.CrowdingModel;

namespace LinesLDN.Models
{
    public class CrowdingModel
    {
        [JsonProperty("naptan")]
        public string naptan { get; set; }

        [JsonProperty("dayOfWeek")]
        public string dayOfWeek { get; set; }

        [JsonProperty("amPeakTimeBand")]
        public string amPeakTimeBand { get; set; }

        [JsonProperty("pmPeakTimeBand")]
        public string pmPeakTimeBand { get; set; }

        [JsonProperty("timeBands")]
        public List<TimeBand> timeBands { get; set; }

        public class TimeBand
        {
            [JsonProperty("timeBand")]
            public string timeBand { get; set; }

            [JsonProperty("percentageOfBaseLine")]
            public double percentageOfBaseLine { get; set; }
        }
    }
}
