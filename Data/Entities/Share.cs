using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CoreCodeCamp.Models;

namespace CoreCodeCamp.Data.Entities
{
    public class Share
    {
        //[ForeignKey("Competitor")]
        [Key]
        public int ShareId { get; set; }
        public double PriceEarningsRatio { get; set; }
        public string CompanyName { get; set; }
        public double NetChangeCash { get; set; }
        public double CashFlow
        { get; set; }
        public double DividendYield
        { get; set; }
        public double SharePrice
        { get; set; }
        public DateTime ShareEntryDate
        { get; set; }
        public double NetDebt { get; set; }
        public double MarketCap { get; set; }

        public Competitor Competitor { get; set; }
        public ShareStrategy ShareStrategy { get; set; }

        public bool YetToIpo { get; set; }
    }
}
