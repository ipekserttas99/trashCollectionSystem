using Data_Homework_.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Homework_.Context
{
    public interface ITrashSystemDbContext
    {
        DbSet<Container> Container { get; set; }
        DbSet<Vehicle> Vehicle { get; set; }

        int SaveChanges();
    }
}
