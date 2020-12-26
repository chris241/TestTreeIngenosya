using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testTreeAPI.Models
{
    public class SyntheseApi
    {
        [JsonProperty("categorie")]
        public string Categorie { get; set; }
        [JsonProperty("nombre")]
        public int Nombre { get; set; }
        [JsonProperty("pourcentage")]
        public double Pourcentage { get; set; }
    }
}