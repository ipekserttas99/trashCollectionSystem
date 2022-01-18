using AutoMapper;
using Data_Homework_.Context;
using Data_Homework_.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Homework_.ViewModels
{
    public class UpdateContainerViewModel
    {
        public string ContainerName { get; set; }
        [Column(TypeName = "decimal(10, 6)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(10, 6)")]
        public decimal Longitude { get; set; }
    }
}
