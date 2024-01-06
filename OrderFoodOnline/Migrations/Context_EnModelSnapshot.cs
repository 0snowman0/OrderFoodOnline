﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderFoodOnline.Model.ConnectionToBank;

#nullable disable

namespace OrderFoodOnline.Migrations
{
    [DbContext(typeof(Context_En))]
    partial class Context_EnModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OrderFoodOnline.Model.Analyes.Analyes_En", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int>("TotalAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("analyes_Ens");
                });

            modelBuilder.Entity("OrderFoodOnline.Model.Analyes.ProductAnalyes_En", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("Analyes_En_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfSale")
                        .HasColumnType("datetime2");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int?>("{Analyes_En_Id}")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("{Analyes_En_Id}");

                    b.ToTable("productAnalyes_Ens");
                });

            modelBuilder.Entity("OrderFoodOnline.Model.Buy.Payment_En", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSuccess")
                        .HasColumnType("bit");

                    b.Property<int>("RestaurntId")
                        .HasColumnType("int");

                    b.Property<string>("TrackingCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("payment_Ens");
                });

            modelBuilder.Entity("OrderFoodOnline.Model.Comment.CommentFood_En", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int?>("IdCommentReplye")
                        .HasColumnType("int");

                    b.Property<bool>("IsReplye")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReport")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("commentFood_Ens");
                });

            modelBuilder.Entity("OrderFoodOnline.Model.Comment.CommentRestaurant_En", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdCommentReplye")
                        .HasColumnType("int");

                    b.Property<bool>("IsReplye")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReport")
                        .HasColumnType("bit");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("commentRestaurant_Ens");
                });

            modelBuilder.Entity("OrderFoodOnline.Model.Comment.Score_En", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Restaurant_Id")
                        .HasColumnType("int");

                    b.Property<int>("score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("score_Ens");
                });

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

            modelBuilder.Entity("OrderFoodOnline.Model.T_Relation_T.Delivery_Restaurant_Relation_En", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Delivery_Id")
                        .HasColumnType("int");

                    b.Property<int>("Restaurant_Id")
                        .HasColumnType("int");

                    b.Property<int?>("{Delivery_Id}")
                        .HasColumnType("int");

                    b.Property<int?>("{Restaurant_Id}")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("{Delivery_Id}");

                    b.HasIndex("{Restaurant_Id}");

                    b.ToTable("delivery_Restaurant_Relation_Ens");
                });

            modelBuilder.Entity("OrderFoodOnline.Model.T_Relation_T.Location_Restaurant_Relation_En", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("location_Id")
                        .HasColumnType("int");

                    b.Property<int>("restaurant_Id")
                        .HasColumnType("int");

                    b.Property<int?>("{location_Id}")
                        .HasColumnType("int");

                    b.Property<int?>("{restaurant_Id}")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("{location_Id}");

                    b.HasIndex("{restaurant_Id}");

                    b.ToTable("location_Restaurant_Relation_Ens");
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

            modelBuilder.Entity("OrderFoodOnline.Model.User.Restaurant_En", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<int>("rate")
                        .HasColumnType("int");

                    b.HasKey("Id");

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

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("OrderFoodOnline.Model.job.recruitment.Recruitment_En", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Restaurant_EnId")
                        .HasColumnType("int");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)");

                    b.Property<string>("file_Name")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("restaurant_id")
                        .HasColumnType("int");

                    b.Property<string>("salary")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("Restaurant_EnId");

                    b.ToTable("recruitment_Ens");
                });

            modelBuilder.Entity("OrderFoodOnline.Model.Analyes.ProductAnalyes_En", b =>
                {
                    b.HasOne("OrderFoodOnline.Model.Analyes.Analyes_En", "analyes")
                        .WithMany("productAnalyes_Ens")
                        .HasForeignKey("{Analyes_En_Id}");

                    b.Navigation("analyes");
                });

            modelBuilder.Entity("OrderFoodOnline.Model.Product.Food.Food_En", b =>
                {
                    b.HasOne("OrderFoodOnline.Model.User.Restaurant_En", "restaurant_En")
                        .WithMany("food_Ens")
                        .HasForeignKey("{restaurant_Id}");

                    b.Navigation("restaurant_En");
                });

            modelBuilder.Entity("OrderFoodOnline.Model.T_Relation_T.Delivery_Restaurant_Relation_En", b =>
                {
                    b.HasOne("OrderFoodOnline.Model.User.Delivery_En", "delivery_Ens")
                        .WithMany()
                        .HasForeignKey("{Delivery_Id}");

                    b.HasOne("OrderFoodOnline.Model.User.Restaurant_En", "restaurant_Ens")
                        .WithMany()
                        .HasForeignKey("{Restaurant_Id}");

                    b.Navigation("delivery_Ens");

                    b.Navigation("restaurant_Ens");
                });

            modelBuilder.Entity("OrderFoodOnline.Model.T_Relation_T.Location_Restaurant_Relation_En", b =>
                {
                    b.HasOne("OrderFoodOnline.Model.Location.Location_En", "location_En")
                        .WithMany()
                        .HasForeignKey("{location_Id}");

                    b.HasOne("OrderFoodOnline.Model.User.Restaurant_En", "restaurant_En")
                        .WithMany()
                        .HasForeignKey("{restaurant_Id}");

                    b.Navigation("location_En");

                    b.Navigation("restaurant_En");
                });

            modelBuilder.Entity("OrderFoodOnline.Model.job.recruitment.Recruitment_En", b =>
                {
                    b.HasOne("OrderFoodOnline.Model.User.Restaurant_En", null)
                        .WithMany("recruitment_Ens")
                        .HasForeignKey("Restaurant_EnId");
                });

            modelBuilder.Entity("OrderFoodOnline.Model.Analyes.Analyes_En", b =>
                {
                    b.Navigation("productAnalyes_Ens");
                });

            modelBuilder.Entity("OrderFoodOnline.Model.User.Restaurant_En", b =>
                {
                    b.Navigation("food_Ens");

                    b.Navigation("recruitment_Ens");
                });
#pragma warning restore 612, 618
        }
    }
}
