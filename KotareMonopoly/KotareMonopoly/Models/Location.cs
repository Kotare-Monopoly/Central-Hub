using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KotareMonopoly.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public int NumberOfHouses { get; set; } //Not MVP
        public virtual Player Owner { get; set; }  // Not MVP
    }
}