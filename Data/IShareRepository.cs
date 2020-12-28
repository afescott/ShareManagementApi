using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreCodeCamp.Data
{
  public interface IShareRepository
  {
        void Add<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        Task<bool> InsertCompany();

    }
}