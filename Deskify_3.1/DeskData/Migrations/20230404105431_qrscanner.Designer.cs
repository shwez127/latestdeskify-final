﻿// <auto-generated />
using System;
using DeskData.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DeskData.Migrations
{
    [DbContext(typeof(DeskDbContext))]
    [Migration("20230404105431_qrscanner")]
    partial class qrscanner
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DeskEntity.Model.BookingRoom", b =>
                {
                    b.Property<int>("BookingRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MeetingEnd")
                        .HasColumnType("datetime2");

                    b.Property<string>("MeetingHours")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MeetingStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("RoomStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BookingRoomId");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("RoomId");

                    b.ToTable("bookingRooms");
                });

            modelBuilder.Entity("DeskEntity.Model.BookingSeat", b =>
                {
                    b.Property<int>("BookingSeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SeatId")
                        .HasColumnType("int");

                    b.Property<string>("SeatShiftTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeatStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("ShiftEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ShiftStart")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("bookingrequesttype")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookingSeatId");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("SeatId");

                    b.ToTable("bookingSeats");
                });

            modelBuilder.Entity("DeskEntity.Model.Choices", b =>
                {
                    b.Property<int>("ChoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BookingSeatId")
                        .HasColumnType("int");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodPerferences")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChoiceId");

                    b.HasIndex("BookingSeatId");

                    b.ToTable("choices");
                });

            modelBuilder.Entity("DeskEntity.Model.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeNumber")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityQuestion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeID");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("DeskEntity.Model.Floor", b =>
                {
                    b.Property<int>("FloorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FloorName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FloorId");

                    b.ToTable("floors");
                });

            modelBuilder.Entity("DeskEntity.Model.LoginTable", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("LoginTables");
                });

            modelBuilder.Entity("DeskEntity.Model.QRScanner", b =>
                {
                    b.Property<int>("QId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BookingSeatId")
                        .HasColumnType("int");

                    b.Property<byte[]>("QRCode")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("QId");

                    b.HasIndex("BookingSeatId");

                    b.ToTable("qrscanners");
                });

            modelBuilder.Entity("DeskEntity.Model.Receptionist", b =>
                {
                    b.Property<int>("ReceptionistID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BookingSeatId")
                        .HasColumnType("int");

                    b.Property<string>("REmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RPassword")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReceptionistID");

                    b.HasIndex("BookingSeatId");

                    b.ToTable("receptionists");
                });

            modelBuilder.Entity("DeskEntity.Model.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("FloorId")
                        .HasColumnType("int");

                    b.Property<bool>("RStatus")
                        .HasColumnType("bit");

                    b.Property<string>("RoomNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomId");

                    b.HasIndex("FloorId");

                    b.ToTable("rooms");
                });

            modelBuilder.Entity("DeskEntity.Model.Seat", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("FloorId")
                        .HasColumnType("int");

                    b.Property<string>("SeatNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("SeatId");

                    b.HasIndex("FloorId");

                    b.ToTable("seats");
                });

            modelBuilder.Entity("DeskEntity.Model.SecretKey", b =>
                {
                    b.Property<int>("SecretId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<byte[]>("QRCode")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SecretKeyGen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecretKeyType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SecretId");

                    b.HasIndex("EmployeeID");

                    b.ToTable("secretKeys");
                });

            modelBuilder.Entity("DeskEntity.Model.BookingRoom", b =>
                {
                    b.HasOne("DeskEntity.Model.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeskEntity.Model.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("DeskEntity.Model.BookingSeat", b =>
                {
                    b.HasOne("DeskEntity.Model.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeskEntity.Model.Seat", "Seat")
                        .WithMany()
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Seat");
                });

            modelBuilder.Entity("DeskEntity.Model.Choices", b =>
                {
                    b.HasOne("DeskEntity.Model.BookingSeat", "BookingSeat")
                        .WithMany()
                        .HasForeignKey("BookingSeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookingSeat");
                });

            modelBuilder.Entity("DeskEntity.Model.Employee", b =>
                {
                    b.HasOne("DeskEntity.Model.LoginTable", "LoginTable")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoginTable");
                });

            modelBuilder.Entity("DeskEntity.Model.QRScanner", b =>
                {
                    b.HasOne("DeskEntity.Model.BookingSeat", "BookingSeat")
                        .WithMany()
                        .HasForeignKey("BookingSeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookingSeat");
                });

            modelBuilder.Entity("DeskEntity.Model.Receptionist", b =>
                {
                    b.HasOne("DeskEntity.Model.BookingSeat", "BookingSeat")
                        .WithMany()
                        .HasForeignKey("BookingSeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookingSeat");
                });

            modelBuilder.Entity("DeskEntity.Model.Room", b =>
                {
                    b.HasOne("DeskEntity.Model.Floor", "Floor")
                        .WithMany()
                        .HasForeignKey("FloorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Floor");
                });

            modelBuilder.Entity("DeskEntity.Model.Seat", b =>
                {
                    b.HasOne("DeskEntity.Model.Floor", "Floor")
                        .WithMany()
                        .HasForeignKey("FloorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Floor");
                });

            modelBuilder.Entity("DeskEntity.Model.SecretKey", b =>
                {
                    b.HasOne("DeskEntity.Model.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
