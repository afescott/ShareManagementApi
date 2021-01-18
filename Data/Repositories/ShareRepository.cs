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
  public class ShareRepository : IShareRepository
  {
    private readonly ShareContext _context;
    private readonly ILogger<ShareRepository> _logger;

    public ShareRepository(ShareContext context, ILogger<ShareRepository> logger)
    {
      _context = context;
      _logger = logger;
    }
        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
            _context.Add(entity);
            
        }

        public void AddOrUpdate(object entity, bool isUpdate)
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

  
            //switch (state)
            //{
            //    case EntityState.Detached:
            //        _context.Add(entity);
            //        break;
            //    case EntityState.Modified:
            //        _context.Update(entity);
            //        break;
            //    case EntityState.Added:
            //    case EntityState.Deleted:
            //    case EntityState.Unchanged:
            //        // do nothing
            //        break;
            //}
        }

     

        public async Task<Share[]> GetAllUserShares(DateTime dateTime)
        {
            _logger.LogInformation($"Getting all Camps");

            IQueryable<Share> query = _context.Shares;
                //.Include(c => c.DividendYield);

            
            // Order It
            //query = query.OrderByDescending(c => c.ShareEntryDate)
            //  .Where(c => c.ShareEntryDate.Date == dateTime.Date);

            return await query.ToArrayAsync();


        }

        public async Task<Share[]> GetShareCompetitorsInfo(int shareId)
        {
            
            IQueryable<Share> query = _context.Shares;

            var results = query.Select(x => x).Where(xx => xx.ShareId == shareId).ToArrayAsync();

            return await results;
        }

        public async Task<Competitor[]> GetCompetitors(int shareId)
        {
            _logger.LogInformation($"Getting all Camps");

            IQueryable<Competitor> query = _context.Competitor;

            var result = query.Select(x => x).Where(xx => xx.ShareId == shareId);

            return await result.ToArrayAsync();
        }

        public async Task<ShareStrategy>  GetShareStrategy(int shareId)
        {
            _logger.LogInformation($"Getting all Camps");

            IQueryable<ShareStrategy> query = _context.ShareStrategy;

           var result = query.Select(x => x).Where(xx => xx.ShareId == shareId).FirstOrDefaultAsync();

            return await result;
        }

        public async Task<bool> InsertCompany()
        {
            _logger.LogInformation($"Attempitng to save the changes in the context");

            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0; 
        }

        public async Task<bool> SaveChangesAsync()
        {
            _logger.LogInformation($"Attempitng to save the changes in the context");

            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
