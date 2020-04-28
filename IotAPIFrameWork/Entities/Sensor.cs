using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValeIotApi.Entities
{
    public class Sensor:Entity
    {
        [Required]
        public long DeviceTypeId { get; set; }
        [Required]
        public long LocationId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual DeviceType DeviceType { get; set; }
        public virtual Location Location { get; set; }                
        //public virtual ICollection<SensorMeasurement> SensorMeasurements { get; set; }
    }
}
