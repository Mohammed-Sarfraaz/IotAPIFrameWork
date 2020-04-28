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
        public string ToleranceName { get; set; }
        [Required]
        public decimal ToleranceHighValue { get; set; }
        [Required]
        public decimal ToleranceLowValue { get; set; }
        [Required]
        public long SensorId { get; set; }
        [Required]
        public long MeasurementTypeId { get; set; }
        public string Description { get; set; }
        public virtual Sensor Sensor { get; set; }
        public virtual MeasurementType MeasurementType { get; set; }        
    }
}
