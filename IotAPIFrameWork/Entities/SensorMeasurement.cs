using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValeIotApi.Entities
{
    public class SensorMeasurement : Entity
    {
        [Required]
        public long SensorId { get; set; }
        [Required]
        public long MeasurementTypeId { get; set; }
        [Required]
        public long LocationId { get; set; }  
        [Required]
        public decimal MeasuredValue { get; set; }
        [Required]
        public string RawData { get; set; }
        public System.DateTime MeasuredDate { get; set; }
        public virtual Sensor Sensor { get; set; }
        public virtual MeasurementType MeasurementType { get; set; }
        public virtual Location Location { get; set; }
    }
}
