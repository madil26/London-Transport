using Newtonsoft.Json;

namespace LinesLDN.Models
{
    public class LiveCrowding
    {
        [JsonProperty("percentageOfBaseLine")]
        public float percentageOfBaseLine { get; set; }
    }
}