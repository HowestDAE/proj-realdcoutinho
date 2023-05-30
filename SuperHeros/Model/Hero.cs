using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SuperHeros.Model
{
    internal class Hero
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "powerstats")]
        public PowerStats PowerStats { get; set; }

        [JsonProperty(PropertyName = "image")]
        public ImageURL ImageImage { get; set; }

        [JsonProperty(PropertyName = "biography")]
        public Biography Biography { get; set; }

    }

    internal class PowerStats
    {
        [JsonProperty(PropertyName = "intelligence")]
        public string Intelligence { get; set; }

        [JsonProperty(PropertyName = "strength")]
        public string Strength { get; set; }

        [JsonProperty(PropertyName = "speed")]
        public string Speed { get; set; }

        [JsonProperty(PropertyName = "durability")]
        public string Durability { get; set; }

        [JsonProperty(PropertyName = "power")]
        public string Power { get; set; }

        [JsonProperty(PropertyName = "combat")]
        public string Combat { get; set; }
    }

    internal class ImageURL
    {
        [JsonProperty(PropertyName = "url")]
        public string url { get; set; }
    }

    internal class Biography 
    {
        [JsonProperty(PropertyName = "full-name")]
        public string fullName { get; set; }

        [JsonProperty(PropertyName = "place-of-birth")]
        public string placeOfBirth { get; set; }

        [JsonProperty(PropertyName = "first-appearance")]
        public string firstAppearance { get; set; }

        [JsonProperty(PropertyName = "publisher")]
        public string publisher { get; set; }

    }
}
