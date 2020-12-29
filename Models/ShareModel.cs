using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCodeCamp.Models
{
    public class ShareModel //represents only the relevant information we're looking for 
    {
        public double SharePrice { get; set; }
        public double PriceEarningsRatio { get; set; }
        public double DividendYield { get; set; }
        public DateTime ShareEntryDate { get; set; }

    }
}
