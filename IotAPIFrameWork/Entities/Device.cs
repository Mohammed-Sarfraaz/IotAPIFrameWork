using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValeIotApi.Entities
{
    public class Device : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SerialNo { get; set; }

        public string Description { get; set; }
 
        //public virtual ICollection<Sensor> Sensors { get; set; }
    }
}
