using Newtonsoft.Json;
using System.Text.Json;

namespace LinesLDN.Models
{
    public class Lines
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("modeName")]
        public string ModeName { get; set; }

        [JsonProperty("lineStatuses")]
        public List<LineStatus> LineStatuses { get; set; }
    }

    public class LineStatus
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("statusSeverity")]
        public int StatusSeverity { get; set; }

        [JsonProperty("statusSeverityDescription")]
        public string StatusSeverityDescription { get; set; }

        [JsonProperty("reason")]
        public string reason { get; set; }
    }
}







