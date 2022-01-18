using AutoMapper;
using Dapper;
using Data_Homework_.ContainerRepo;
using Data_Homework_.Context;
using Data_Homework_.Entities;
using Data_Homework_.Uow;
using Data_Homework_.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectionSystem.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<VehicleController> _logger;
        private readonly IMapper _mapper;

        public VehicleController(ILogger<VehicleController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IQueryable<Vehicle> GetAllVehicles()
        {
            return unitOfWork.Vehicle.GetAll();

        }

        [HttpGet("{id}")]
        public Task<Vehicle> GetVehicleById(int id)
        {
             return unitOfWork.Vehicle.GetById(id);
            
        }

        [HttpPost]
        public Vehicle CreateVehicle([FromBody] CreateVehicleViewModel createVehicle)
        {
            return unitOfWork.Vehicle.Create(createVehicle);
        }

        [HttpPut("{id}")]
        public Vehicle UpdateVehicle(int id,[FromBody] UpdateVehicleViewModel updatedVehicle)
        {
            return unitOfWork.Vehicle.Update(id, updatedVehicle);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            await unitOfWork.Vehicle.Delete(id);
            return Ok();
        }

    }
}
