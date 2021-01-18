using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCodeCamp.Models
{
    public class FundModel //represents only the relevant information we're looking for 
    {
        public int FundId { get; set; }
        public string FundName { get; set; }
        public bool YetToIpo { get; set; }
        public bool IsEtf { get; set; }
        public double NetAssets { get; set; }
        public double DividendYield { get; set; }


    }
}
