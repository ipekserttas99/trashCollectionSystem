using AutoMapper;
using Data_Homework_.ContainerRepo;
using Data_Homework_.Context;
using Data_Homework_.VehicleRepo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Homework_.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ILogger logger;
        private readonly IConfiguration _configuration;
        private readonly TrashSystemDbContext context;
        private readonly IMapper _mapper;

        public IContainerRepository Container { get; private set; }
        public IVehicleRepository Vehicle { get; private set; }

        public UnitOfWork(TrashSystemDbContext context, ILoggerFactory loggerFactory, IConfiguration configuration, IMapper mapper)
        {
            this.context = context;
            this.logger = loggerFactory.CreateLogger("TrashCollection");
            _mapper = mapper;

            Container = new ContainerRepository(context, logger, _mapper);
            Vehicle = new VehicleRepository(context, logger, _mapper);
        }
        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
