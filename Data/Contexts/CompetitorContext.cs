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
    public class CompetitorContext : DbContext
    {
        private readonly IConfiguration _config;

        public DbSet<CompetitorModel> ShareStrategy { get; set; }

        public CompetitorContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            this._config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("CodeCamp"));
        }

        protected override void OnModelCreating(ModelBuilder bldr)
        {
            bldr.Entity<Competitor>(u =>
            {
                u.HasKey(b =>  new  { b.ShareId, b.CompetitorId});
                u.Property(b => b.ShareId).ValueGeneratedOnAdd();
                u.HasData(new
                {
                    ShareId = 21,
                    CompetitorShareId = 21
                });


            });
        }

    }
}
