using CoreCodeCamp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreCodeCamp.Data
{
  public interface IFundRepository
    {
        void Add<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        Task<Fund[]> GetAllFunds();
        void AddOrUpdateFundStrategy(object entity, bool isUpdate);

        Task<FundStrategy> GetFundStrategy(int shareId);
    }
}