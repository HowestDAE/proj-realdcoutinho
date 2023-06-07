using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SuperHeros.Model
{
    public class Hero
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

        [JsonProperty(PropertyName = "appearance")]
        public Appearance Appearance { get; set; }

        [JsonProperty(PropertyName = "work")]
        public Work Work { get; set; }

        [JsonProperty(PropertyName = "connections")]
        public Connections Connections { get; set; }
    }

    public class Biography
    {
        [JsonProperty(PropertyName = "publisher")]
        public string Publisher { get; set; }

        [JsonProperty(PropertyName = "full-name")]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "alter-egos")]
        public string AlterEgos { get; set; }

        [JsonProperty(PropertyName = "place-of-birth")]
        public string PlaceOfBirth { get; set; }

        [JsonProperty(PropertyName = "first-appearance")]
        public string FirstAppearance { get; set; }
    }


    public class PowerStats
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


    public class Appearance
    {
        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }

        [JsonProperty(PropertyName = "height")]
        public List<string> Height { get; set; }

        [JsonProperty(PropertyName = "weight")]
        public List<string> Weight { get; set; }

        [JsonProperty(PropertyName = "eye-color")]
        public string EyeColor { get; set; }

        [JsonProperty(PropertyName = "hair-color")]
        public string HairColor { get; set; }
    }

    public class Work
    {
        [JsonProperty(PropertyName = "occupation")]
        public string Occupation { get; set; }

        [JsonProperty(PropertyName = "base")]
        public string Base { get; set; }
    }

    public class Connections
    {
        [JsonProperty(PropertyName = "group-affiliation")]
        public string GroupAffiliation { get; set; }

        [JsonProperty(PropertyName = "relatives")]
        public string Relatives { get; set; }
    }

    public class ImageURL
    {
        [JsonProperty(PropertyName = "url")]
        public string url { get; set; }
    }

}
