using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCodeCamp.Models
{
    public class ShareStrategyModel
    {
       [Key]
        public int StrategyId { get; set; }

    
        public int ShareFundId { get; set; }

        public bool isFund { get; set; }
     
        public string PlanForIncrease { get; set; }
       
        public string TimingJustification { get; set; }

        public string PlanFor20Decrease { get; set; }

        public string PlanFor40Decrease { get; set; }


    }
}
