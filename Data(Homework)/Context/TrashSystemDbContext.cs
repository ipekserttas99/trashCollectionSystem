using Data_Homework_.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Homework_.Context
{
    public class TrashSystemDbContext : DbContext, ITrashSystemDbContext
    {
        public TrashSystemDbContext(DbContextOptions<TrashSystemDbContext> options) : base(options)
        {

        }

        public DbSet<Container> Container { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
