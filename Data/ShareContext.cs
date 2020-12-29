using CoreCodeCamp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCodeCamp.Data
{
    public class ShareContext : DbContext
    {
        private readonly IConfiguration _config;

        public ShareContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            this._config = config;
        }


        public DbSet<Share> Shares { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("CodeCamp"));
        }

        protected override void OnModelCreating(ModelBuilder bldr)
        {
          

        
            bldr.Entity<Company>(u =>
            {
                u.HasKey(b => b.CompanyId);
                u.Property(b => b.CompanyId).ValueGeneratedOnAdd();
                u.HasData(new
                {
                    CompanyId = 1,
                    CompanyName = "Frank",
                    PreTaxProfitThisYear = 25.5,
                    PreTaxProfitLastYear = 50.5,
                    NetDebt = 25.50,
                    MarketCap = 25.15
                });
            });

            bldr.Entity<Share>(u =>
            {
                u.HasKey(b => b.ShareId);
                u.Property(b => b.ShareId).ValueGeneratedOnAdd();
                u.HasData(new
                {
                    ShareId = 1,
                    SharePrice = 25.5,
                    DividendYield = 50.5,
                    ShareEntryDate = DateTime.Today
                });
            });
            //bldr.Entity<Company>()
            //.HasData(new
            //{
            //    CompanyName = "Frank",
            //    PreTaxProfitThisYear = 25.5,
            //    PreTaxProfitLastYear = 50.5,
            //    NetDebt = 25.50,
            //    MarketCap = 25.15
            //});



        }


    }
}
