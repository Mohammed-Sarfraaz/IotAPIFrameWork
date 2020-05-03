using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValeIotApi.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;

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
                    SeedDevice(db);
                   // SeedLocations(db);                                  
                }
            }
        }

        private static void SeedDevice(SQLiteDBContext db)
        {
            if (!db.Devices.Any())
            {
                 Pi.Init<BootstrapWiringPi>();

                db.Devices.AddAsync(new Device
                {
                    SerialNo = Pi.Info.Serial,
                    Name ="RaspberryPi - " + Pi.Info.BoardModel.ToString(),
                    Description = Pi.Info.ModelName
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

    }
}
