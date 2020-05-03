﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValeIotApi.Entities
{
    public class MeasurementType : Entity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public long SensorId { get; set; }
        //public virtual ICollection<SensorMeasurement> SensorMeasurements { get; set; }
    }
}
