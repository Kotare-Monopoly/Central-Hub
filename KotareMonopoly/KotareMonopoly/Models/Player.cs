﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using Newtonsoft.Json;

namespace KotareMonopoly.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public int CurrentPositionId { get; set; }
        [JsonIgnore]
        public virtual List<Location> OwnedProperties { get; set; } //NOT MVP
    }
}