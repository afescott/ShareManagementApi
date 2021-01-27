
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreCodeCamp.Data
{
  public class Fund
    {
        [Key]
        public int FundId { get; set; }
        public string FundName { get; set; }
        public bool YetToIpo { get; set; }
        public bool IsEtf { get; set; }
        public double NetAssets { get; set; }
        public double DividendYield { get; set; }
    }
}