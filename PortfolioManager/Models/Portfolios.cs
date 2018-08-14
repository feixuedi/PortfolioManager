using System;
using System.Collections.Generic;

namespace PortfolioManager.Models
{
    public partial class Portfolios
    {
        public Portfolios()
        {
            Positions = new HashSet<Positions>();
            PtfValuePerDay = new HashSet<PtfValuePerDay>();
            Trades = new HashSet<Trades>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Soeid { get; set; }
        public decimal Limit { get; set; }
        public string Policy { get; set; }
        public decimal Cash { get; set; }
        public DateTime CreateDate { get; set; }

        public Users Soe { get; set; }
        public ICollection<Positions> Positions { get; set; }
        public ICollection<PtfValuePerDay> PtfValuePerDay { get; set; }
        public ICollection<Trades> Trades { get; set; }
    }
}
