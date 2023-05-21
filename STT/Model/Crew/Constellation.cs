using Newtonsoft.Json;

namespace STT.Model.Crew
{
    public class Constellation
    {
        /// <summary>
        /// id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// short_name
        /// </summary>
        [JsonProperty("short_name")]
        public string ShortName { get; set; }

        /// <summary>
        /// flavor
        /// </summary>
        [JsonProperty("flavor")]
        public string Flavor { get; set; }

        /// <summary>
        /// icon
        /// </summary>
        [JsonProperty("icon")]
        public ImageAsset Icon { get; set; }

        /// <summary>
        /// keystones
        /// </summary>
        [JsonProperty("keystones")]
        public int[] Keystones { get; set; }

        /// <summary>
        /// type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// crew_archetype_id
        /// </summary>
        [JsonProperty("crew_archetype_id")]
        public int CrewArchetypeId { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Flavor})";
        }
    }

}
