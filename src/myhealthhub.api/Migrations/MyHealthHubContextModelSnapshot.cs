﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using myhealthhub.api.Models;

#nullable disable

namespace myhealthhub.api.Migrations
{
    [DbContext(typeof(MyHealthHubContext))]
    partial class MyHealthHubContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("myhealthhub.api.Models.Entities.FormLabel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FormsLabels");
                });

            modelBuilder.Entity("myhealthhub.api.Models.Entities.FormLabelPerVisit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FormLabelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VisitId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FormLabelId");

                    b.HasIndex("VisitId");

                    b.ToTable("FormLabelsPerVisits");
                });

            modelBuilder.Entity("myhealthhub.api.Models.Entities.Visit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTimeVisit")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("myhealthhub.api.Models.Entities.FormLabelPerVisit", b =>
                {
                    b.HasOne("myhealthhub.api.Models.Entities.FormLabel", "FormLabel")
                        .WithMany("FormsLabelsPerVisits")
                        .HasForeignKey("FormLabelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("myhealthhub.api.Models.Entities.Visit", "Visit")
                        .WithMany("FormsLabelsPerVisits")
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FormLabel");

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("myhealthhub.api.Models.Entities.FormLabel", b =>
                {
                    b.Navigation("FormsLabelsPerVisits");
                });

            modelBuilder.Entity("myhealthhub.api.Models.Entities.Visit", b =>
                {
                    b.Navigation("FormsLabelsPerVisits");
                });
#pragma warning restore 612, 618
        }
    }
}
