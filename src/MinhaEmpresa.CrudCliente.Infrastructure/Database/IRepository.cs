using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MinhaEmpresa.CrudCliente.Crosscutting.Specification;
using Microsoft.EntityFrameworkCore.Storage;

namespace MinhaEmpresa.CrudCliente.Infrastructure.Database
{
    public interface IRepository<TEntity>
    {

        Task<TEntity> Save(TEntity entity);
        Task Delete(TEntity entity);
        Task Update(TEntity entity);
        Task<TEntity> Get(object id);
        Task<IEnumerable<TEntity>> GetAllByCriteria(ISpecification<TEntity> specification);
        Task<TEntity> GetOneByCriteria(ISpecification<TEntity> specification);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IDbContextTransaction> CreateTransaction();
        Task<IDbContextTransaction> CreateTransaction(System.Data.IsolationLevel isolation = System.Data.IsolationLevel.Serializable);
        Task<IEnumerable<TEntity>> GetAllByCriteria(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetOneByCriteria(Expression<Func<TEntity, bool>> expression);
    }
}
