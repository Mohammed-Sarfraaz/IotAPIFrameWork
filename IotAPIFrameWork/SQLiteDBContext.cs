using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ValeIotApi.Entities;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace ValeIotApi
{
    public class SQLiteDBContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }
        
        public DbSet<Location> Locations { get; set; }

        public DbSet<SensorMeasurement> SensorMeasurements { get; set; }

        public DbSet<SensorTolerance> SensorTolerances { get; set; }

        public DbSet<MeasurementType> MeasurementTypes { get; set; }

        public DbSet<Sensor> Sensors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=iot.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>().ToTable("Devices")          
             .Property(e => e.Id)
             .ValueGeneratedOnAdd();
            modelBuilder.Entity<Location>().ToTable("Locations")
             .Property(e => e.Id)
             .ValueGeneratedOnAdd();
            modelBuilder.Entity<SensorTolerance>().ToTable("SensorTolerances")
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<MeasurementType>().ToTable("MeasurementTypes")
             .Property(e => e.Id)
             .ValueGeneratedOnAdd();
            modelBuilder.Entity<Sensor>().ToTable("Sensors")
             .Property(e => e.Id)
             .ValueGeneratedOnAdd();
            modelBuilder.Entity<SensorMeasurement>().ToTable("SensorMeasurements")
              .Property(e => e.Id)
             .ValueGeneratedOnAdd();

        }

    }


}
