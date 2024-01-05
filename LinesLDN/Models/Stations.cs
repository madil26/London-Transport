using Newtonsoft.Json;

namespace LinesLDN.Models
{
    public class Stations
    {
        [JsonProperty("naptanId")]
		public string naptanId { get; set; }

		[JsonProperty("commonName")]
		public string commonName { get; set; }

        [JsonProperty("stopType")]
        public string stopType { get; set; }
    }

}
