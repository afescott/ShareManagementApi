using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CoreCodeCamp.Data.Entities;

namespace CoreCodeCamp.Models
{
    public class CompetitorModel
    {
        //[Key]
      
        public int CompetitorShareId { get; set; }
        public int ShareId { get; set; }

        //[RelatedTo(ForeignKey = "CompanyId")]
       
        public int  CompetitorId { get; set; }

        public Share Share { get; set; }

    }
}
