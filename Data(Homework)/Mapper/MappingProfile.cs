using AutoMapper;
using Data_Homework_.Entities;
using Data_Homework_.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Homework_.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateContainerViewModel, Container>();
            CreateMap<Container, CreateContainerViewModel>();
            CreateMap<CreateVehicleViewModel, Vehicle>();
            CreateMap<Vehicle, CreateVehicleViewModel>();
            CreateMap<UpdateContainerViewModel, Container>();
            CreateMap<Container, UpdateContainerViewModel>();
            CreateMap<UpdateVehicleViewModel, Vehicle>();
            CreateMap<Vehicle, UpdateVehicleViewModel>();
        }
    }
}
