using Data_Homework_.Generic;
using Data_Homework_.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Homework_.ViewModels;

namespace Data_Homework_.ContainerRepo
{
    public interface IContainerRepository : IGenericRepository<Container>
    {
        Container Create(CreateContainerViewModel createContainerModel);
        Container Update(int id, UpdateContainerViewModel updateContainerModel);
    }
}
