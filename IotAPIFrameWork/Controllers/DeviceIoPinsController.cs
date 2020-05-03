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
    [Route("api/DeviceIoPinsController")]
    public class DeviceIoPinsController : ControllerBase
    {
        private readonly ILogger<DeviceIoPinsController> _logger;

        
        public DeviceIoPinsController(ILogger<DeviceIoPinsController> logger)
        {
            _logger = logger;
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

        [HttpGet]
        public ActionResult<Device> GetDeviceInfo()
        {
            Pi.Init<BootstrapWiringPi>();

            var device = new Device
            {
                SerialNo = Pi.Info.Serial,
                Name = "RaspberryPi - " + Pi.Info.BoardModel.ToString(),
                Description = Pi.Info.ModelName
            };

            return device;//"DeviceInfo :----"+Pi.Info.ToString() +" GOPI Pins :----"+ Pi.Gpio.ToString();
        }

    }
}
