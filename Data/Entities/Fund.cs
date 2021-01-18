
using System;
using System.Collections.Generic;

namespace CoreCodeCamp.Data
{
  public class Fund
    {
      public int FundId { get; set; }
      public string FundName { get; set; }
      public bool YetToIpo { get; set; }
      public bool IsEtf { get; set; }
      public double NetAssets { get; set; }
      public double DividendYield { get; set; }
        public ShareStrategy ShareStrategy { get; set; }
    }
}