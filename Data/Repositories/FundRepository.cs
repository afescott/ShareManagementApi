using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreCodeCamp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CoreCodeCamp.Data
{
  public class FundRepository : IFundRepository
  {
    private readonly FundContext _context;
    private readonly ILogger<FundRepository> _logger;

    public FundRepository(FundContext context, ILogger<FundRepository> logger)
    {
      _context = context;
      _logger = logger;
    }
        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
            _context.Add(entity);
            
        }


        public async Task<bool> SaveChangesAsync()
        {
            _logger.LogInformation($"Attempitng to save the changes in the context");

            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Fund[]> GetAllFunds()
        {
            _logger.LogInformation($"Getting all Camps");

            IQueryable<Fund> query = _context.Funds;

            return await query.ToArrayAsync();
        }

        public void AddOrUpdateFundStrategy(object entity, bool isUpdate)
        {
            var state = _context.Entry(entity).State;

            if (isUpdate)
            {
                _context.Update(entity);
            }
            else
            {
                _context.Add(entity);
            }
        }

        public async Task<FundStrategy> GetFundStrategy(int shareId)
        {
            _logger.LogInformation($"Getting all Camps");

            IQueryable<FundStrategy> query = _context.FundStrategy;

            var result = query.Select(x => x).Where(xx => xx.FundId == shareId).FirstOrDefaultAsync();

            return await result;
        }
  }
}
