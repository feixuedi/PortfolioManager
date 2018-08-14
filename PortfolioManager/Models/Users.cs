using System;
using System.Collections.Generic;

namespace PortfolioManager.Models
{
    public partial class Users
    {
        public Users()
        {
            Portfolios = new HashSet<Portfolios>();
        }

        public string Soeid { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Password { get; set; }
        public decimal Limit { get; set; }

        public ICollection<Portfolios> Portfolios { get; set; }
    }
}
