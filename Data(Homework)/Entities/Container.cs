using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data_Homework_.Entities
{
    public class Container 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ContainerName { get; set; }
        [Column(TypeName = "decimal(10, 6)")]
        public decimal Latitude { get;set; }
        [Column(TypeName = "decimal(10, 6)")]
        public decimal Longitude { get; set; }
        public int VehicleId { get; set; }
    }
}
