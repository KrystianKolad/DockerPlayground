using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Kube.Api.Models;

namespace Kube.Api.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        Task AddAsync(T model);
        Task<IEnumerable<T>> GetAsync();
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
    }
}