using AutoMapper;
using Dapper;
using Data_Homework_.Context;
using Data_Homework_.Generic;
using Data_Homework_.Entities;
using Data_Homework_.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data_Homework_.ContainerRepo
{
    public class ContainerRepository : GenericRepository<Container> , IContainerRepository
    {
        private readonly IMapper _mapper;
        
        public ContainerRepository(TrashSystemDbContext dbContext, ILogger logger, IMapper mapper) : base(dbContext, logger)
        {
            _mapper = mapper;
        }

        public Container Create(CreateContainerViewModel createContainerViewModel)
        {
            
            var container = _dbContext.Container.SingleOrDefault(c => c.ContainerName == createContainerViewModel.ContainerName);
            container = _mapper.Map<Container>(createContainerViewModel);
            
            _dbContext.Container.Add(container);
            _dbContext.SaveChanges();
            return container;
            
        }

        public Container Update(int id,UpdateContainerViewModel updateContainerModel)
        {

            var container = _dbContext.Container.Where(container => container.Id == id).SingleOrDefault();
            _mapper.Map(updateContainerModel, container);
            _dbContext.SaveChanges();

            return container;
        }
    }
}
