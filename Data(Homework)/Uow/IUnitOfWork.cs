using Data_Homework_.ContainerRepo;
using Data_Homework_.VehicleRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Homework_.Uow
{
    public interface IUnitOfWork
    {
        IVehicleRepository Vehicle { get; }
        IContainerRepository Container { get; }

        int Complete();
    }
}
