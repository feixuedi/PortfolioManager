using System;
using System.Collections.Generic;

namespace PortfolioManager.Models
{
    public partial class Trades
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public int Ptfid { get; set; }
        public int Qty { get; set; }

        public Portfolios Ptf { get; set; }
    }
}
