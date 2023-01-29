﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VG_ApiF.Models;

#nullable disable

namespace VGApiF.Migrations
{
    [DbContext(typeof(VgDatabaseContext))]
    [Migration("20230129000436_intial")]
    partial class intial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VG_ApiF.Models.Citizen", b =>
                {
                    b.Property<int>("CitiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("citi_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CitiId"));

                    b.Property<string>("CitiAddress")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("citi_address");

                    b.Property<string>("CitiCity")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("citi_city");

                    b.Property<string>("CitiContactdetails")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("citi_contactdetails");

                    b.Property<string>("CitiEmail")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("citi_email");

                    b.Property<string>("CitiLastname")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("citi_lastname");

                    b.Property<string>("CitiName")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("citi_name");

                    b.Property<string>("CitiPassword")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("citi_password");

                    b.Property<string>("CitiProvince")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("citi_province");

                    b.Property<string>("CitiStatus")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("citi_status");

                    b.HasKey("CitiId");

                    b.ToTable("Citizens");
                });

            modelBuilder.Entity("VG_ApiF.Models.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("job_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobId"));

                    b.Property<DateTime?>("JobDateend")
                        .HasColumnType("date")
                        .HasColumnName("job_dateend");

                    b.Property<DateTime?>("JobDatestart")
                        .HasColumnType("date")
                        .HasColumnName("job_datestart");

                    b.Property<string>("JobStatus")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("job_status");

                    b.Property<TimeSpan?>("JobTimeend")
                        .HasColumnType("time")
                        .HasColumnName("job_timeend");

                    b.Property<TimeSpan?>("JobTimestart")
                        .HasColumnType("time")
                        .HasColumnName("job_timestart");

                    b.Property<int>("OfiId")
                        .HasColumnType("int")
                        .HasColumnName("ofi_id");

                    b.Property<int>("RId")
                        .HasColumnType("int")
                        .HasColumnName("r_id");

                    b.HasKey("JobId");

                    b.HasIndex("OfiId");

                    b.HasIndex("RId");

                    b.ToTable("Job", (string)null);
                });

            modelBuilder.Entity("VG_ApiF.Models.Official", b =>
                {
                    b.Property<int>("OfiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ofi_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OfiId"));

                    b.Property<string>("OfiAddress")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("ofi_address");

                    b.Property<string>("OfiBadge")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("ofi_badge");

                    b.Property<string>("OfiContactdetails")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("ofi_contactdetails");

                    b.Property<string>("OfiEmail")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("ofi_email");

                    b.Property<string>("OfiLastname")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("ofi_lastname");

                    b.Property<string>("OfiName")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("ofi_name");

                    b.Property<string>("OfiPasssend")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("ofi_passsend");

                    b.Property<string>("OfiPassword")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("ofi_password");

                    b.Property<string>("OfiPic")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("ofi_pic");

                    b.Property<string>("OfiStatus")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("ofi_status");

                    b.Property<string>("OfiType")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("ofi_type");

                    b.HasKey("OfiId");

                    b.ToTable("Officials");
                });

            modelBuilder.Entity("VG_ApiF.Models.Report", b =>
                {
                    b.Property<int>("RId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("r_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RId"));

                    b.Property<int>("CitiId")
                        .HasColumnType("int")
                        .HasColumnName("citi_id");

                    b.Property<int>("OfiId")
                        .HasColumnType("int")
                        .HasColumnName("ofi_id");

                    b.Property<string>("RAddress")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("r_address");

                    b.Property<string>("RCity")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("r_city");

                    b.Property<DateTime?>("RDatereported")
                        .HasColumnType("date")
                        .HasColumnName("r_datereported");

                    b.Property<DateTime?>("RDateupdated")
                        .HasColumnType("date")
                        .HasColumnName("r_dateupdated");

                    b.Property<string>("RDescription")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("r_description");

                    b.Property<string>("RLat")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("r_lat");

                    b.Property<string>("RLocationpoint")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("r_locationpoint");

                    b.Property<string>("RLong")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("r_long");

                    b.Property<string>("RPics1")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("r_pics1");

                    b.Property<string>("RPics2")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("r_pics2");

                    b.Property<string>("RPics3")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("r_pics3");

                    b.Property<string>("RProvince")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("r_province");

                    b.Property<string>("RStatus")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("r_status");

                    b.Property<TimeSpan?>("RTimereported")
                        .HasColumnType("time")
                        .HasColumnName("r_timereported");

                    b.Property<string>("RType")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("r_type");

                    b.Property<DateTime?>("RViewdate")
                        .HasColumnType("date")
                        .HasColumnName("r_viewdate");

                    b.Property<TimeSpan?>("RViewtime")
                        .HasColumnType("time")
                        .HasColumnName("r_viewtime");

                    b.HasKey("RId");

                    b.HasIndex("CitiId");

                    b.HasIndex("OfiId");

                    b.ToTable("Report", (string)null);
                });

            modelBuilder.Entity("VG_ApiF.Models.ReportComment", b =>
                {
                    b.Property<int>("RcId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("rc_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RcId"));

                    b.Property<int>("CitiId")
                        .HasColumnType("int")
                        .HasColumnName("citi_id");

                    b.Property<int>("OfiId")
                        .HasColumnType("int")
                        .HasColumnName("ofi_id");

                    b.Property<int>("RId")
                        .HasColumnType("int")
                        .HasColumnName("r_id");

                    b.Property<string>("RcComment")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("rc_comment");

                    b.Property<DateTime?>("RcDate")
                        .HasColumnType("date")
                        .HasColumnName("rc_date");

                    b.Property<TimeSpan?>("RcTime")
                        .HasColumnType("time")
                        .HasColumnName("rc_time");

                    b.HasKey("RcId");

                    b.HasIndex("CitiId");

                    b.HasIndex("OfiId");

                    b.HasIndex("RId");

                    b.ToTable("ReportComment", (string)null);
                });

            modelBuilder.Entity("VG_ApiF.Models.Job", b =>
                {
                    b.HasOne("VG_ApiF.Models.Official", "Ofi")
                        .WithMany("Jobs")
                        .HasForeignKey("OfiId")
                        .IsRequired()
                        .HasConstraintName("FK_Job_Officials");

                    b.HasOne("VG_ApiF.Models.Report", "RIdNavigation")
                        .WithMany("Jobs")
                        .HasForeignKey("RId")
                        .IsRequired()
                        .HasConstraintName("FK_Job_Report");

                    b.Navigation("Ofi");

                    b.Navigation("RIdNavigation");
                });

            modelBuilder.Entity("VG_ApiF.Models.Report", b =>
                {
                    b.HasOne("VG_ApiF.Models.Citizen", "Citi")
                        .WithMany("Reports")
                        .HasForeignKey("CitiId")
                        .IsRequired()
                        .HasConstraintName("FK_Report_Citizens");

                    b.HasOne("VG_ApiF.Models.Official", "Ofi")
                        .WithMany("Reports")
                        .HasForeignKey("OfiId")
                        .IsRequired()
                        .HasConstraintName("FK_Report_Officials");

                    b.Navigation("Citi");

                    b.Navigation("Ofi");
                });

            modelBuilder.Entity("VG_ApiF.Models.ReportComment", b =>
                {
                    b.HasOne("VG_ApiF.Models.Citizen", "Citi")
                        .WithMany("ReportComments")
                        .HasForeignKey("CitiId")
                        .IsRequired()
                        .HasConstraintName("FK_ReportComment_Citizens");

                    b.HasOne("VG_ApiF.Models.Official", "Ofi")
                        .WithMany("ReportComments")
                        .HasForeignKey("OfiId")
                        .IsRequired()
                        .HasConstraintName("FK_ReportComment_Officials");

                    b.HasOne("VG_ApiF.Models.Report", "RIdNavigation")
                        .WithMany("ReportComments")
                        .HasForeignKey("RId")
                        .IsRequired()
                        .HasConstraintName("FK_ReportComment_Report");

                    b.Navigation("Citi");

                    b.Navigation("Ofi");

                    b.Navigation("RIdNavigation");
                });

            modelBuilder.Entity("VG_ApiF.Models.Citizen", b =>
                {
                    b.Navigation("ReportComments");

                    b.Navigation("Reports");
                });

            modelBuilder.Entity("VG_ApiF.Models.Official", b =>
                {
                    b.Navigation("Jobs");

                    b.Navigation("ReportComments");

                    b.Navigation("Reports");
                });

            modelBuilder.Entity("VG_ApiF.Models.Report", b =>
                {
                    b.Navigation("Jobs");

                    b.Navigation("ReportComments");
                });
#pragma warning restore 612, 618
        }
    }
}
