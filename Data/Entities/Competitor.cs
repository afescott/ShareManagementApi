
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoreCodeCamp.Data.Entities;

namespace CoreCodeCamp.Data
{
  public class Competitor
  {
        [Key]
        public int CompetitorShareId { get; set; }

        
        public int ShareId { get; set; }

        //[RelatedTo(ForeignKey = "CompanyId")]

        public int CompetitorId { get; set; }

        public  Share Share { get; set; }
    }
}