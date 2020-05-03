﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ValeIotApi;

namespace IotAPIFrameWork.Migrations
{
    [DbContext(typeof(SQLiteDBContext))]
    partial class SQLiteDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("ValeIotApi.Entities.Device", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SerialNo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("ValeIotApi.Entities.Location", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("ValeIotApi.Entities.MeasurementType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("SensorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SensorId");

                    b.ToTable("MeasurementTypes");
                });

            modelBuilder.Entity("ValeIotApi.Entities.Sensor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<long>("DeviceId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("LocationId");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("ValeIotApi.Entities.SensorMeasurement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MeasuredDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("MeasuredValue")
                        .HasColumnType("TEXT");

                    b.Property<long>("MeasurementTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RawData")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("SensorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementTypeId");

                    b.HasIndex("SensorId");

                    b.ToTable("SensorMeasurements");
                });

            modelBuilder.Entity("ValeIotApi.Entities.SensorTolerance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<long>("MeasurementTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("SensorId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("ToleranceHighValue")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ToleranceLowValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("ToleranceName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementTypeId");

                    b.HasIndex("SensorId");

                    b.ToTable("SensorTolerances");
                });

            modelBuilder.Entity("ValeIotApi.Entities.MeasurementType", b =>
                {
                    b.HasOne("ValeIotApi.Entities.Sensor", null)
                        .WithMany("MeasurementTypes")
                        .HasForeignKey("SensorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ValeIotApi.Entities.Sensor", b =>
                {
                    b.HasOne("ValeIotApi.Entities.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ValeIotApi.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ValeIotApi.Entities.SensorMeasurement", b =>
                {
                    b.HasOne("ValeIotApi.Entities.MeasurementType", "MeasurementType")
                        .WithMany()
                        .HasForeignKey("MeasurementTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ValeIotApi.Entities.Sensor", "Sensor")
                        .WithMany()
                        .HasForeignKey("SensorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ValeIotApi.Entities.SensorTolerance", b =>
                {
                    b.HasOne("ValeIotApi.Entities.MeasurementType", "MeasurementType")
                        .WithMany()
                        .HasForeignKey("MeasurementTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ValeIotApi.Entities.Sensor", "Sensor")
                        .WithMany()
                        .HasForeignKey("SensorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
