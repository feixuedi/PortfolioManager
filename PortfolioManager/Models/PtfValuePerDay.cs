using System;
using System.Collections.Generic;

namespace PortfolioManager.Models
{
    public partial class PtfValuePerDay
    {
        public int Id { get; set; }
        public int Ptfid { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }

        public Portfolios Ptf { get; set; }
    }
}
