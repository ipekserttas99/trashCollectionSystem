using AutoMapper;
using Dapper;
using Data_Homework_.Context;
using Data_Homework_.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Homework_.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ILogger logger;
        protected readonly TrashSystemDbContext _dbContext;
        internal DbSet<TEntity> dbSet;
        
        public GenericRepository(TrashSystemDbContext dbContext, ILogger logger)
        {
            this.logger = logger;
            _dbContext = dbContext;
            dbSet = _dbContext.Set<TEntity>();

        }


        public async Task Delete(int id)
        {
            
            var entity = await dbSet.FindAsync(id);
            dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbSet.AsNoTracking();
        }


        public async Task<TEntity> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }


        public List<List<Container>> GetClusteredContainers(List<Container> containers, int N)
        {
            int lengthoflist = containers.Count();

            int e = lengthoflist / N;

            List<List<Container>> list = new List<List<Container>>();


            int sonEleman = 0;
            List<Container> list3 = new List<Container>();
            for (int i = 0; i < N; i++)
            {
                List<Container> list2 = new List<Container>();

                for (int j = i * e; j < (e * (i + 1)); j++)
                {

                    list2.Add(containers[j]);
                    sonEleman = j;
                    list3 = list2;
                }
                list.Add(list2);


            }

            for (int i = sonEleman + 2; i < lengthoflist; i++)
            {

                list3.Add(containers[i]);


            }

            return list;
        }

    }
}
