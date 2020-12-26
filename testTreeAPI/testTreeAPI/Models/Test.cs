using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testTreeConsole.Dao;

namespace testTreeAPI.Models
{
    public class Test
    {
        [JsonProperty("categorie")]
        public string Categorie { get; set; }

    }
}