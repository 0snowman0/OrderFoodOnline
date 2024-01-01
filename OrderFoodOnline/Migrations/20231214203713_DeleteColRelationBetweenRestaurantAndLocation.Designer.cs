﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderFoodOnline.Model.ConnectionToBank;

#nullable disable

namespace OrderFoodOnline.Migrations
{
    [DbContext(typeof(Context_En))]
    [Migration("20231214203713_DeleteColRelationBetweenRestaurantAndLocation")]
    partial class DeleteColRelationBetweenRestaurantAndLocation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OrderFoodOnline.Model.Location.Location_En", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("location_Ens");
                });

            modelBuilder.Entity("OrderFoodOnline.Model.Product.Food.Food_En", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("OriginalPhotoName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("food_Type_Em")
                        .HasColumnType("int");

                    b.Property<string>("ingredients")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("preparation_time")
                        .HasColumnType("int");

                    b.Property<int>("rating")
                        .HasColumnType("int");

                    b.Property<int>("restaurant_Id")
                        .HasColumnType("int");

                    b.Property<string>("restaurant_name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("serving_size")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("{restaurant_Id}")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("{restaurant_Id}");

                    b.ToTable("food_Ens");
                });

            modelBuilder.Entity("OrderFoodOnline.Model.User.Delivery_En", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("typeofVehicles")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("delivery_Ens");
                });

            modelBuilder.Entity("OrderFoodOnline.Model.User.Delivery_Restaurant_Relation_En", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Delivery_Id")
                        .HasColumnType("int");

                    b.Property<int>("Restaurant_Id")
                        .HasColumnType("int");

                    b.Property<int>("{Delivery_Id}")
                        .HasColumnType("int");

                    b.Property<int>("{Restaurant_Id}")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("{Delivery_Id}");

                    b.HasIndex("{Restaurant_Id}");

                    b.ToTable("delivery_Restaurant_Relation_Ens");
                });

            modelBuilder.Entity("OrderFoodOnline.Model.User.Restaurant_En", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<int?>("locationId")
                        .HasColumnType("int");

                    b.Property<int>("rate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("locationId");

                    b.ToTable("restaurant_Ens");
                });

            modelBuilder.Entity("OrderFoodOnline.Model.User.User_En", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TokenCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("user_Ens");
                });

            modelBuilder.Entity("OrderFoodOnline.Model.Product.Food.Food_En", b =>
                {
                    b.HasOne("OrderFoodOnline.Model.User.Restaurant_En", "restaurant_En")
                        .WithMany("food_Ens")
                        .HasForeignKey("{restaurant_Id}");

                    b.Navigation("restaurant_En");
                });

            modelBuilder.Entity("OrderFoodOnline.Model.User.Delivery_Restaurant_Relation_En", b =>
                {
                    b.HasOne("OrderFoodOnline.Model.User.Delivery_En", "delivery_Ens")
                        .WithMany()
                        .HasForeignKey("{Delivery_Id}")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrderFoodOnline.Model.User.Restaurant_En", "restaurant_Ens")
                        .WithMany()
                        .HasForeignKey("{Restaurant_Id}")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("delivery_Ens");

                    b.Navigation("restaurant_Ens");
                });

            modelBuilder.Entity("OrderFoodOnline.Model.User.Restaurant_En", b =>
                {
                    b.HasOne("OrderFoodOnline.Model.Location.Location_En", "location")
                        .WithMany()
                        .HasForeignKey("locationId");

                    b.Navigation("location");
                });

            modelBuilder.Entity("OrderFoodOnline.Model.User.Restaurant_En", b =>
                {
                    b.Navigation("food_Ens");
                });
#pragma warning restore 612, 618
        }
    }
}
