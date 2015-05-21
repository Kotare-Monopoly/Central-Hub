using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KotareMonopoly.Models
{
    public class Board
    {
        public int Id { get; set; }
        public virtual List<Location> BoardLocations { get; set; }
    }
}