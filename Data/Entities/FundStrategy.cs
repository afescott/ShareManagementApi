using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.ComTypes;
using CoreCodeCamp.Data.Entities;

namespace CoreCodeCamp.Data
{
    public class FundStrategy
    {

        //[ForeignKey("Share")]
        [Key]
        public int FundId { get; set; }

        public string PlanForIncrease { get; set; }

        public string TimingJustification { get; set; }

        public string PlanFor20Decrease { get; set; }

        public string PlanFor40Decrease { get; set; }


        //public Share Share { get; set; }
        //[ForeignKey("ShareFundId")]


    }
}