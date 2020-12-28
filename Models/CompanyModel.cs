using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCodeCamp.Models
{
    public class CompanyModel //represents only the relevant information we're looking for 
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public double PreTaxProfitThisYear { get; set; }
        public double PreTaxProfitLastYear { get; set; }
        public double NetDebt { get; set; }
        public double MarketCap { get; set; }


    }
}
