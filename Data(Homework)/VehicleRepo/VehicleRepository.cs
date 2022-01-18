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

namespace Data_Homework_.VehicleRepo
{
    public class VehicleRepository : GenericRepository<Vehicle>,IVehicleRepository
    {
        private readonly IMapper _mapper;
        public VehicleRepository(TrashSystemDbContext dbContext, ILogger logger, IMapper mapper) : base(dbContext, logger)
        {
            _mapper = mapper;
        }

      

        public Vehicle Create(CreateVehicleViewModel createVehicleModel)
        {
            var vehicle = _dbContext.Vehicle.SingleOrDefault(v => v.VehiclePlate == createVehicleModel.VehiclePlate);
            vehicle = _mapper.Map<Vehicle>(createVehicleModel);

            _dbContext.Vehicle.Add(vehicle);
            _dbContext.SaveChanges();

            return vehicle;
        }

        public async Task Delete(int id)
        {
            var sql = "DELETE FROM Vehicle WHERE Id = " + id +
                "DELETE FROM Container WHERE VehicleId = " + id;
            using (var connection = new SqlConnection("Server=IPEK; Database=trashcollectionsystem; Trusted_Connection=True;"))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
            }
        }

        

        public Vehicle Update(int id, UpdateVehicleViewModel updateVehicleModel)
        {
            var vehicle = _dbContext.Vehicle.Where(vehicle => vehicle.Id == id).SingleOrDefault();
            _mapper.Map(updateVehicleModel, vehicle);
            _dbContext.SaveChanges();

            return vehicle;
        }
    }
}
