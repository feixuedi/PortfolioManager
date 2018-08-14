using System;
using System.Collections.Generic;

namespace PortfolioManager.Models
{
    public partial class Instruments
    {
        public Instruments()
        {
            Prices = new HashSet<Prices>();
        }

        public string Symbol { get; set; }
        public string Type { get; set; }

        public ICollection<Prices> Prices { get; set; }
    }
}
