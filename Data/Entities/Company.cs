
using System;
using System.Collections.Generic;

namespace CoreCodeCamp.Data
{
  public class Company
  {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public double PreTaxProfitThisYear { get; set; }
        public double PreTaxProfitLastYear { get; set; }
        public double NetDebt { get; set; }
        public double MarketCap { get; set; }
    }
}