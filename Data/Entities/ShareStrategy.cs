
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoreCodeCamp.Data.Entities;

namespace CoreCodeCamp.Data
{
    public class ShareStrategy
    {
        [Key]
        public int ShareId { get; set; }

        public string PlanForIncrease { get; set; }

      public string TimingJustification { get; set; }

        public string PlanFor20Decrease { get; set; }

      public string PlanFor40Decrease { get; set; }

        [ForeignKey("ShareId")]
        public Share Share { get; set; }
        //[ForeignKey("ShareFundId")]
        //public Fund Fund { get; set; }

    }
}