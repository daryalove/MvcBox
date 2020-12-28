﻿// <auto-generated />
using System;
using Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entities.Migrations.SmartBox
{
    [DbContext(typeof(SmartBoxContext))]
    [Migration("20191216202251_AddCompleteToTask")]
    partial class AddCompleteToTask
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Models.Alarm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Acknowledge")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AcknowledgedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<Guid>("AlarmTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BoxId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleasedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AlarmTypeId");

                    b.HasIndex("BoxId");

                    b.ToTable("Alarms");
                });

            modelBuilder.Entity("Entities.Models.AlarmType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("AlarmTypes");
                });

            modelBuilder.Entity("Entities.Models.Driver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BoxCount")
                        .HasColumnType("int");

                    b.Property<int>("BoxState")
                        .HasColumnType("int");

                    b.Property<bool>("IsBusy")
                        .HasColumnType("bit");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("Entities.Models.DriverHasBox", b =>
                {
                    b.Property<Guid>("BoxId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DriverId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BoxId", "DriverId");

                    b.HasIndex("DriverId");

                    b.ToTable("DriverHasBoxes");
                });

            modelBuilder.Entity("Entities.Models.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BoxId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.HasKey("Id");

                    b.HasIndex("BoxId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Entities.Models.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("Altitude")
                        .HasColumnType("float");

                    b.Property<Guid>("BoxId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CurrentDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("SignalLevel")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BoxId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Entities.Models.ModbusVariable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Address")
                        .HasColumnType("int");

                    b.Property<int>("Function")
                        .HasColumnType("int");

                    b.Property<int>("PollingTime")
                        .HasColumnType("int");

                    b.Property<int>("Sign")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<bool>("Trackable")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<Guid>("VariableId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VariableId");

                    b.ToTable("ModbusVariables");
                });

            modelBuilder.Entity("Entities.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CargoClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CargoType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DestinationLatitude")
                        .HasColumnType("float");

                    b.Property<double>("DestinationLongitude")
                        .HasColumnType("float");

                    b.Property<double>("Distance")
                        .HasColumnType("float");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<string>("InceptionAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("InceptionLatitude")
                        .HasColumnType("float");

                    b.Property<double>("InceptionLongitude")
                        .HasColumnType("float");

                    b.Property<double>("Insurance")
                        .HasColumnType("float");

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<string>("LoadMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OrderStageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PaymentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("ShipmentTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.Property<double>("Width")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OrderStageId");

                    b.HasIndex("PaymentId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Entities.Models.OrderHasBox", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BoxId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsBusy")
                        .HasColumnType("bit");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BoxId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderHasBoxes");
                });

            modelBuilder.Entity("Entities.Models.OrderStage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.HasKey("Id");

                    b.ToTable("OrderStages");
                });

            modelBuilder.Entity("Entities.Models.OrderStageLog", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderStageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId", "OrderStageId");

                    b.HasIndex("OrderStageId");

                    b.ToTable("OrderStageLogs");
                });

            modelBuilder.Entity("Entities.Models.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("PaidAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("PayStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Entities.Models.Rate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("HRate")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("Entities.Models.Sensor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<Guid>("BoxId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bus")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<Guid>("SensorTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BoxId");

                    b.HasIndex("SensorTypeId");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("Entities.Models.SensorData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SensorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SensorId");

                    b.ToTable("SensorDatas");
                });

            modelBuilder.Entity("Entities.Models.SensorType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SensorTypes");
                });

            modelBuilder.Entity("Entities.Models.SmartBox", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("BatteryPower")
                        .HasColumnType("float");

                    b.Property<int>("BoxState")
                        .HasColumnType("int");

                    b.Property<string>("CloudKey")
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DriverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsOpenedBox")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOpenedDoor")
                        .HasColumnType("bit");

                    b.Property<int>("Light")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Temperature")
                        .HasColumnType("float");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.Property<double>("Wetness")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("SmartBoxes");
                });

            modelBuilder.Entity("Entities.Models.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AbortedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("AbortedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DoneAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DriverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TaskPriority")
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<string>("TaskType")
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WayPoints")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("OrderId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Entities.Models.UserHasAccess", b =>
                {
                    b.Property<Guid>("BoxId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BoxId", "UserId");

                    b.ToTable("UserHasAccesses");
                });

            modelBuilder.Entity("Entities.Models.UserHasOrder", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrderId", "UserId");

                    b.ToTable("UserHasOrders");
                });

            modelBuilder.Entity("Entities.Models.Variable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BoxId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DefaultValue")
                        .HasColumnType("nvarchar(512)")
                        .HasMaxLength(512);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Modifiable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(512)")
                        .HasMaxLength(512);

                    b.Property<Guid>("VariableGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BoxId");

                    b.HasIndex("VariableGroupId");

                    b.ToTable("Variables");
                });

            modelBuilder.Entity("Entities.Models.VariableGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Function")
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<Guid>("VariableGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VariableGroupId");

                    b.ToTable("VariableGroups");
                });

            modelBuilder.Entity("Entities.Models.VariableNotify", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VariableId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VariableId");

                    b.ToTable("VariableNotifies");
                });

            modelBuilder.Entity("Entities.Models.Alarm", b =>
                {
                    b.HasOne("Entities.Models.AlarmType", null)
                        .WithMany("Alarms")
                        .HasForeignKey("AlarmTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Entities.Models.SmartBox", null)
                        .WithMany("Alarms")
                        .HasForeignKey("BoxId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.DriverHasBox", b =>
                {
                    b.HasOne("Entities.Models.SmartBox", null)
                        .WithMany("DriverHasBoxes")
                        .HasForeignKey("BoxId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Entities.Models.Driver", null)
                        .WithMany("DriverHasBoxes")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Event", b =>
                {
                    b.HasOne("Entities.Models.SmartBox", null)
                        .WithMany("Events")
                        .HasForeignKey("BoxId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Location", b =>
                {
                    b.HasOne("Entities.Models.SmartBox", null)
                        .WithMany("Locations")
                        .HasForeignKey("BoxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.ModbusVariable", b =>
                {
                    b.HasOne("Entities.Models.Variable", null)
                        .WithMany("ModbusVariables")
                        .HasForeignKey("VariableId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Order", b =>
                {
                    b.HasOne("Entities.Models.OrderStage", null)
                        .WithMany("Orders")
                        .HasForeignKey("OrderStageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Payment", null)
                        .WithMany("Orders")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.OrderHasBox", b =>
                {
                    b.HasOne("Entities.Models.SmartBox", null)
                        .WithMany("OrderHasBoxes")
                        .HasForeignKey("BoxId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Entities.Models.Order", null)
                        .WithMany("OrderHasBoxes")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("Entities.Models.OrderStageLog", b =>
                {
                    b.HasOne("Entities.Models.Order", null)
                        .WithMany("OrderStageLogs")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Entities.Models.OrderStage", null)
                        .WithMany("OrderStageLogs")
                        .HasForeignKey("OrderStageId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Sensor", b =>
                {
                    b.HasOne("Entities.Models.SmartBox", null)
                        .WithMany("Sensors")
                        .HasForeignKey("BoxId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Entities.Models.SensorType", null)
                        .WithMany("Sensors")
                        .HasForeignKey("SensorTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.SensorData", b =>
                {
                    b.HasOne("Entities.Models.Sensor", null)
                        .WithMany("SensorDatas")
                        .HasForeignKey("SensorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Task", b =>
                {
                    b.HasOne("Entities.Models.Driver", null)
                        .WithMany("Tasks")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Entities.Models.Order", null)
                        .WithMany("Tasks")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.UserHasAccess", b =>
                {
                    b.HasOne("Entities.Models.SmartBox", null)
                        .WithMany("UserHasAccesses")
                        .HasForeignKey("BoxId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.UserHasOrder", b =>
                {
                    b.HasOne("Entities.Models.Order", null)
                        .WithMany("UserHasOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Variable", b =>
                {
                    b.HasOne("Entities.Models.SmartBox", null)
                        .WithMany("Variables")
                        .HasForeignKey("BoxId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Entities.Models.VariableGroup", null)
                        .WithMany("Variables")
                        .HasForeignKey("VariableGroupId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.VariableGroup", b =>
                {
                    b.HasOne("Entities.Models.VariableGroup", null)
                        .WithMany("VariableGroupes")
                        .HasForeignKey("VariableGroupId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.VariableNotify", b =>
                {
                    b.HasOne("Entities.Models.Variable", null)
                        .WithMany("VariableNotifies")
                        .HasForeignKey("VariableId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
