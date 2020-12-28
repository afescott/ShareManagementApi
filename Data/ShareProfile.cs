using AutoMapper;
using CoreCodeCamp.Data.Entities;
using CoreCodeCamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCodeCamp.Data
{
    public class ShareProfile : Profile //i believe this happens automatically / must do
    {
        public ShareProfile()
        {
            this.CreateMap<Share, ShareModel>();
            this.CreateMap<ShareModel, Share>();
            this.CreateMap<Company, CompanyModel>();
            this.CreateMap<CompanyModel, Company>();
        }
         
    }
}
