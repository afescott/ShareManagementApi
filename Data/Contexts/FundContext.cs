using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCodeCamp.Data.Entities;
using CoreCodeCamp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoreCodeCamp.Data
{
    public class FundContext : DbContext
    {
        private readonly IConfiguration _config;

        public DbSet<Fund> Funds { get; set; }

        public FundContext(DbContextOptions<FundContext> options, IConfiguration config) : base(options)
        {
            this._config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("CodeCamp"));
        }

        protected override void OnModelCreating(ModelBuilder bldr)
        {
            bldr.Entity<Fund>(u =>
            {
                u.HasKey(b => b.FundId);
                u.Property(b => b.FundId).ValueGeneratedOnAdd();

                u.HasData(new
                {
                    FundId = 1,
                    NetAssets = 21.5,
                    DividendYield = 0.5, 
                    IsEtf = false,
                    YetToIpo = false
                });


            });
        }

    }
}
