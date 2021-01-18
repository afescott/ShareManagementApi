using CoreCodeCamp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCodeCamp.Models;

namespace CoreCodeCamp.Data
{
    public class ShareContext : DbContext
    {
        private readonly IConfiguration _config;

        public ShareContext(DbContextOptions<ShareContext> options, IConfiguration config) : base(options)
        {
            this._config = config;
        }

        public DbSet<ShareStrategy> ShareStrategy { get; set; }

        //public DbSet<ShareStrategy> FundStrategy{ get; set; }

      

        public DbSet<Share> Shares { get; set; }
        //public DbSet<Share[]> Shares { get; set; }

        public DbSet<ShareStrategyModel> ShareStrategies { get; set; }

        public DbSet<Competitor> Competitor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("CodeCamp"));
        }

        protected override void OnModelCreating(ModelBuilder bldr)
        {
            bldr.Entity<Competitor>(u =>
            {
                //u.HasMany(b => b.Share)
                //    .WithOne(i => i.Competitor).HasForeignKey(b => b.ShareId);

                u.HasKey(b => b.CompetitorShareId);
                u.Property(b => b.CompetitorShareId).ValueGeneratedOnAdd();

                u.HasOne(b => b.Share)
                    .WithOne(b => b.Competitor);
                
                    
                

                u.HasData(new
                {
                    CompetitorShareId = 500,
                    ShareId = 21,
                    CompetitorId = 21
                });


            });

            //bldr.Entity<ShareStrategy>(u =>
            //{
            //    u.HasOne(b => b.Share)
            //        .WithOne(i => i.ShareStrategy)
            //        .HasForeignKey<Share>(b => b.ShareId);
            //    u.HasKey(b => b.ShareId);
            //    u.HasData(new
            //    {
            //        ShareId = 21,
            //        TimingJustification = "frank",
            //        PlanForIncrease = "Frank",
            //        PlanFor20Decrease = "Frank",
            //        PlanFor40Decrease = "Frank"

            //    });
            //});

            bldr.Entity<ShareStrategy>(u =>
            {
                //u.HasOne(b => b.Fund)
                //   .WithOne(i => i.ShareStrategy)
                //    .HasForeignKey<ShareStrategy>(b => b.ShareFundId);

                //u.HasOne(b => b.Fund)
                //   .WithOne(i => i.ShareStrategy)
                //    .HasForeignKey<ShareStrategy>(b => b.ShareFundId);

                u.HasKey(b => b.ShareId);
                u.Property(b => b.ShareId).ValueGeneratedOnAdd();



                //     u.hasone(e => e.fund)
                //.withone(e => e.sharestrategy)
                //.hasforeignkey<sharestrategy>(p => p.sharefundid);

                //u.HasOne(x => x.ShareFundId).wi

                //       u.hasone(e => e.fund)
                //.withone(e => e.sharestrategy)
                //.hasforeignkey<sharestrategy>(p => new { p.share.shareid, p.fund.fundid });

                //u.HasOne(b => b.Share).WithOne(x => x.ShareStrategy).HasForeignKey<Share>(x => x.ShareId);
                //u.HasOne(b => b.Fund).WithOne(x => x.ShareStrategy).HasForeignKey<Fund>(x => x.FundId);
                u.HasData(new
                {
                  ShareId = 21,
                                TimingJustification = "frank",
                    PlanForIncrease = "Frank",
                    PlanFor20Decrease = "Frank",
                    PlanFor40Decrease = "Frank"

                }) ;

            
                //u.HasKey(b => b.StrategyId);
                //u.Property(b => b.StrategyId);
                //u.HasData(new
                //{
                //    ShareId = 1,
                //    TimingJustification = "frank",
                //    PlanForIncrease = "Frank",
                //    PlanFor20Decrease = "Frank",
                //    PlanFor40Decrease = "Frank"

                //});
            });

          //  bldr.Entity<ShareStrategy>()
          //.HasKey(c =>  c.ShareFundId);

          //  bldr.Entity<ShareStrategy>()
          //       .HasOne(s => s.Fund) // Mark Address property optional in Student entity
          //       .WithOne(x => x.ShareStrategy);


          //  bldr.Entity<ShareStrategy>()
          //       .HasOne(s => s.Share) // Mark Address property optional in Student entity
          //       .WithOne(x => x.ShareStrategy);

            //    bldr.Entity<ShareStrategy>(u =>
            //{
            //    u.HasOne(b => b.Share)
            //        .WithOne(i => i.ShareStrategy)
            //        .HasForeignKey<Share>(b => b.ShareId);
            //    u.HasKey(b => b.ShareId);
            //    u.Property(b => b.ShareId).ValueGeneratedOnAdd();
            //    u.HasData(new
            //        {
            //        ShareId = 21,
            //        TimingJustification = "frank",
            //        PlanForIncrease = "Frank",
            //            PlanFor20Decrease = "Frank",
            //            PlanFor40Decrease = "Frank"

            //        });
            //    });

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
                //u.HasKey(b => b.CompanyId);
                //u.Property(b => b.CompanyId).ValueGeneratedNever();
                //u.HasData(new
                //{
                //    CompanyId = 21,
                //    CompanyName = "Frank",
                //    PreTaxProfitThisYear = 25.5,
                //    PreTaxProfitLastYear = 50.5,
                //    NetDebt = 25.50,
                //    MarketCap = 25.15
                //});
                //});

                bldr.Entity<Share>(u =>
            {
                u.HasKey(b => b.ShareId);
                u.Property(b => b.ShareId).ValueGeneratedOnAdd();

                //u.HasOne(b => b.Competitor)
                //    .WithMany(b => b.Share)
                //    .HasForeignKey(b => b.ShareId).HasPrincipalKey(b => b.CompetitorShareId);

                u.HasOne(b => b.Competitor)
                    .WithOne(b => b.Share);

                u.HasData(new
                {
                    ShareId = 214,
                    CashFlow = 25.1,
                    PriceEarningsRatio = 12.2,
                    NetChangeCash = 65.5,
                    MarketCap = 25.5,
                    NetDebt = 25.5,
                    ShareEntryDate = DateTime.Now,
                    SharePrice = 25.5,
                    DividendYield = 25.5,
                    CompanyName = "jimbob",
                    YetToIpo = false


                });
            });

            //bldr.Entity<Share>(u =>
            //{
            //    u.HasKey(b => b.ShareId);
            //    u.Property(b => b.ShareId).ValueGeneratedOnAdd();
            //    u.has


            //})

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
