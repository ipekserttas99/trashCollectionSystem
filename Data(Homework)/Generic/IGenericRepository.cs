using Data_Homework_.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Homework_.Generic
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        
        Task<TEntity> GetById(int id);
        List<List<Container>> GetClusteredContainers(List<Container> containers, int N);
        Task Delete(int id);
    }
}
