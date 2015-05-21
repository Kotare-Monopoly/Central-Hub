using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace KotareMonopoly.Models
{
    [JsonObject]
    public class DieRoll
    {
        public int dieResult { get; set; }
        public int currentPlayer { get; set; }
    }
}