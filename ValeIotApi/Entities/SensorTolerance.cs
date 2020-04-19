using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValeIotApi.Entities
{
    public class SensorTolerance : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Value { get; set; }

        [Required]
        public long SensorId { get; set; }
        [Required]
        public long MeasurementTypeId { get; set; }
        public string Description { get; set; }
        public virtual Sensor DeviceType { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<SensorMeasurement> SensorMeasurements { get; set; }
    }
}
