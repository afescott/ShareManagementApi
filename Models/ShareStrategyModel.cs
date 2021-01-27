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
       public int ShareId { get; set; }

       public string PlanForIncrease { get; set; }

       public string TimingJustification { get; set; }

       public string PlanFor20Decrease { get; set; }

       public string PlanFor40Decrease { get; set; }

       public bool IsFund { get; set; }
    }
}
