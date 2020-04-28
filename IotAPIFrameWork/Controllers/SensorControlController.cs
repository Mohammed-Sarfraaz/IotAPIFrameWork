using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ValeIotApi.Entities;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;
using System.Collections;

namespace ValeIotApi.Controllers
{
    [ApiController]
    [Route("api/{sensorId}/SensorControlController")]
    public class SensorControlControllerController : ControllerBase
    {
        private readonly ILogger<SensorControlControllerController> _logger;

        private SQLiteDBContext _context { get; set; }

        public SensorControlControllerController(ILogger<SensorControlControllerController> logger, SQLiteDBContext context)
        {
            _logger = logger;
            _context = context;
        }
         
        [HttpGet("{pin_number}/{pin_upOrpin_down}")]
        public string GetTogglePin([FromRoute]bool pin_upOrpin_down, [FromRoute]int pin_number)
        {
            Pi.Init<BootstrapWiringPi>();
            var pin = Pi.Gpio[pin_number];
            pin.PinMode = GpioPinDriveMode.Output;
            pin.Write(pin_upOrpin_down);
            return $"pin {pin.BcmPinNumber} set to {pin_upOrpin_down}";
        }

        [HttpGet("{deviceId}")] 
        public string GetDeviceInfo([FromRoute]int deviceId)
        {
            Pi.Init<BootstrapWiringPi>();
            return "DeviceInfo :----"+Pi.Info.ToString() +" GOPI Pins :----"+ Pi.Gpio.ToString();
        }

    }
}
