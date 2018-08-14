using System;
using System.Collections.Generic;

namespace PortfolioManager.Models
{
    public partial class Positions
    {
        public int Id { get; set; }
        public int Ptfid { get; set; }
        public int Qty { get; set; }
        public DateTime InitialDate { get; set; }
        public string Symbol { get; set; }
        public decimal BidPrice { get; set; }

        public Portfolios Ptf { get; set; }
    }
}
