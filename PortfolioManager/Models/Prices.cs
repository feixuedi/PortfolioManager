using System;
using System.Collections.Generic;

namespace PortfolioManager.Models
{
    public partial class Prices
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public decimal OpenPrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public decimal ChangeRate { get; set; }

        public Instruments SymbolNavigation { get; set; }
    }
}
