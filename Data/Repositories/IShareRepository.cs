using CoreCodeCamp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreCodeCamp.Data
{
  public interface IShareRepository
  {
        void Add<T>(T entity) where T : class;

        void AddOrUpdate(object entity, bool isUpdate);

        Task<bool> SaveChangesAsync();

        Task<bool> InsertCompany();

        Task<Share[]> GetAllUserShares(DateTime date);

        Task<Share[]> GetShareCompetitorsInfo(int shareId);

        Task<Competitor[]> GetCompetitors(int shareId);

        Task<ShareStrategy> GetShareStrategy(int shareId);

    }
}