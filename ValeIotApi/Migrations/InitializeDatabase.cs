using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValeIotApi.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ValeIotApi.Migrations
{
    public class InitializeDatabase
    {
        public static void SeedData(IApplicationBuilder app)
        {
            using (var serviceScope =
                app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var serviceProvider = serviceScope.ServiceProvider;

                using (var db = serviceProvider.GetService<SQLiteDBContext>())
                {
                    SeedDeviceTypes(db);
                    SeedLocations(db);
                    SeedMeasurementTypes(db);                 
                }
            }
        }

        private static void SeedDeviceTypes(SQLiteDBContext db)
        {
            if (!db.DeviceTypes.Any())
            {
                db.DeviceTypes.Add(new DeviceType
                {                  
                    Name = "Adrino",
                    Description = "Adrino1"
                });
                db.DeviceTypes.Add(new DeviceType
                {                 
                    Name = "Raspberry Pi 4",
                    Description = "Raspberry Pi Zero 4"
                });
                db.SaveChanges();
            }
        }

        private static void SeedLocations(SQLiteDBContext db)
        {
            if (!db.Locations.Any())
            {
                db.Locations.AddAsync(new Location
                {                   
                    Name = "Mine1",
                    Description = "Remote Mine1"
                });
                db.Locations.AddAsync(new Location
                {
                    Name = "Mine2",
                    Description = "Remote Mine2"
                });               
                db.SaveChanges();
            }
        }

        private static void SeedMeasurementTypes(SQLiteDBContext db)
        {
            if (!db.MeasurementTypes.Any())
            {
                db.MeasurementTypes.Add(new MeasurementType
                {                   
                    Name = "Temperature",
                    Description = "Ambient temperature in Farhenheit"
                });
                db.MeasurementTypes.Add(new MeasurementType
                {
                    Name = "Humidity",
                    Description = "Level of relative humidity"
                });
                db.MeasurementTypes.Add(new MeasurementType
                {                    
                    Name = "Light",
                    Description = "Light level measured in percent"
                });
                db.SaveChanges();
            }
        }                     

    }
}
