using Newtonsoft.Json;

namespace LinesLDN.Models
{
    public class StationStopPoints
    {
        [JsonProperty("stopPoints")]
        public List<Stations> stopPoints { get; set; }
    }
}
