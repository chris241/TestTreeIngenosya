using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTreeConsole.Dao
{
    public class Synthese
    {
        [JsonProperty("categorie")]
        public string Categorie { get; set; }

        [JsonProperty("nombre")]
        public int Nombre { get; set; }

        [JsonProperty("pourcentage")]
        public int Pourcentage { get; set; }
    }
}
