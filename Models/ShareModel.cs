using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCodeCamp.Models
{
    public class ShareModel //represents only the relevant information we're looking for 
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
       public string ShareEntryDate
{ get; set; }
       public double NetDebt { get; set; }
       public bool YetToIpo { get; set; }

    }
}
