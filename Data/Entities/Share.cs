using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCodeCamp.Data.Entities
{
    public class Share
    {
        public int ShareId { get; set; }
        public double SharePrice { get; set; }
        //public double PriceEarningsRatio { get; set; }
        public double DividendYield { get; set; }
    }
}
