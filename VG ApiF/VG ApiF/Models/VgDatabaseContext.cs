using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VG_ApiF.Models;

public partial class VgDatabaseContext : DbContext
{
    public VgDatabaseContext()
    {
    }

    public VgDatabaseContext(DbContextOptions<VgDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Citizen> Citizens { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Official> Officials { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<ReportComment> ReportComments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-K9P6HGH\\SQLEXPRESS;Database=VG Database;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Citizen>(entity =>
        {
            entity.HasKey(e => e.CitiId);

            entity.Property(e => e.CitiId).HasColumnName("citi_id");
            entity.Property(e => e.CitiAddress)
                .IsUnicode(false)
                .HasColumnName("citi_address");
            entity.Property(e => e.CitiCity)
                .IsUnicode(false)
                .HasColumnName("citi_city");
            entity.Property(e => e.CitiContactdetails)
                .IsUnicode(false)
                .HasColumnName("citi_contactdetails");
            entity.Property(e => e.CitiEmail)
                .IsUnicode(false)
                .HasColumnName("citi_email");
            entity.Property(e => e.CitiLastname)
                .IsUnicode(false)
                .HasColumnName("citi_lastname");
            entity.Property(e => e.CitiName)
                .IsUnicode(false)
                .HasColumnName("citi_name");
            entity.Property(e => e.CitiPassword)
                .IsUnicode(false)
                .HasColumnName("citi_password");
            entity.Property(e => e.CitiProvince)
                .IsUnicode(false)
                .HasColumnName("citi_province");
            entity.Property(e => e.CitiStatus)
                .IsUnicode(false)
                .HasColumnName("citi_status");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.ToTable("Job");

            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.JobDateend)
                .HasColumnType("date")
                .HasColumnName("job_dateend");
            entity.Property(e => e.JobDatestart)
                .HasColumnType("date")
                .HasColumnName("job_datestart");
            entity.Property(e => e.JobStatus)
                .IsUnicode(false)
                .HasColumnName("job_status");
            entity.Property(e => e.JobTimeend).HasColumnName("job_timeend");
            entity.Property(e => e.JobTimestart).HasColumnName("job_timestart");
            entity.Property(e => e.OfiId).HasColumnName("ofi_id");
            entity.Property(e => e.RId).HasColumnName("r_id");

            entity.HasOne(d => d.Ofi).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.OfiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Job_Officials");

            entity.HasOne(d => d.RIdNavigation).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.RId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Job_Report");
        });

        modelBuilder.Entity<Official>(entity =>
        {
            entity.HasKey(e => e.OfiId);

            entity.Property(e => e.OfiId).HasColumnName("ofi_id");
            entity.Property(e => e.OfiAddress)
                .IsUnicode(false)
                .HasColumnName("ofi_address");
            entity.Property(e => e.OfiBadge)
                .IsUnicode(false)
                .HasColumnName("ofi_badge");
            entity.Property(e => e.OfiContactdetails)
                .IsUnicode(false)
                .HasColumnName("ofi_contactdetails");
            entity.Property(e => e.OfiEmail)
                .IsUnicode(false)
                .HasColumnName("ofi_email");
            entity.Property(e => e.OfiLastname)
                .IsUnicode(false)
                .HasColumnName("ofi_lastname");
            entity.Property(e => e.OfiName)
                .IsUnicode(false)
                .HasColumnName("ofi_name");
            entity.Property(e => e.OfiPasssend)
                .IsUnicode(false)
                .HasColumnName("ofi_passsend");
            entity.Property(e => e.OfiPassword)
                .IsUnicode(false)
                .HasColumnName("ofi_password");
            entity.Property(e => e.OfiPic)
                .IsUnicode(false)
                .HasColumnName("ofi_pic");
            entity.Property(e => e.OfiStatus)
                .IsUnicode(false)
                .HasColumnName("ofi_status");
            entity.Property(e => e.OfiType)
                .IsUnicode(false)
                .HasColumnName("ofi_type");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.RId);

            entity.ToTable("Report");

            entity.Property(e => e.RId).HasColumnName("r_id");
            entity.Property(e => e.CitiId).HasColumnName("citi_id");
            entity.Property(e => e.OfiId).HasColumnName("ofi_id");
            entity.Property(e => e.RAddress)
                .IsUnicode(false)
                .HasColumnName("r_address");
            entity.Property(e => e.RCity)
                .IsUnicode(false)
                .HasColumnName("r_city");
            entity.Property(e => e.RDatereported)
                .HasColumnType("date")
                .HasColumnName("r_datereported");
            entity.Property(e => e.RDateupdated)
                .HasColumnType("date")
                .HasColumnName("r_dateupdated");
            entity.Property(e => e.RDescription)
                .IsUnicode(false)
                .HasColumnName("r_description");
            entity.Property(e => e.RLat)
                .IsUnicode(false)
                .HasColumnName("r_lat");
            entity.Property(e => e.RLocationpoint)
                .IsUnicode(false)
                .HasColumnName("r_locationpoint");
            entity.Property(e => e.RLong)
                .IsUnicode(false)
                .HasColumnName("r_long");
            entity.Property(e => e.RPics1)
                .IsUnicode(false)
                .HasColumnName("r_pics1");
            entity.Property(e => e.RPics2)
                .IsUnicode(false)
                .HasColumnName("r_pics2");
            entity.Property(e => e.RPics3)
                .IsUnicode(false)
                .HasColumnName("r_pics3");
            entity.Property(e => e.RProvince)
                .IsUnicode(false)
                .HasColumnName("r_province");
            entity.Property(e => e.RStatus)
                .IsUnicode(false)
                .HasColumnName("r_status");
            entity.Property(e => e.RTimereported).HasColumnName("r_timereported");
            entity.Property(e => e.RType)
                .IsUnicode(false)
                .HasColumnName("r_type");
            entity.Property(e => e.RViewdate)
                .HasColumnType("date")
                .HasColumnName("r_viewdate");
            entity.Property(e => e.RViewtime).HasColumnName("r_viewtime");

            entity.HasOne(d => d.Citi).WithMany(p => p.Reports)
                .HasForeignKey(d => d.CitiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Report_Citizens");

            entity.HasOne(d => d.Ofi).WithMany(p => p.Reports)
                .HasForeignKey(d => d.OfiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Report_Officials");
        });

        modelBuilder.Entity<ReportComment>(entity =>
        {
            entity.HasKey(e => e.RcId);

            entity.ToTable("ReportComment");

            entity.Property(e => e.RcId).HasColumnName("rc_id");
            entity.Property(e => e.CitiId).HasColumnName("citi_id");
            entity.Property(e => e.OfiId).HasColumnName("ofi_id");
            entity.Property(e => e.RId).HasColumnName("r_id");
            entity.Property(e => e.RcComment)
                .IsUnicode(false)
                .HasColumnName("rc_comment");
            entity.Property(e => e.RcDate)
                .HasColumnType("date")
                .HasColumnName("rc_date");
            entity.Property(e => e.RcTime).HasColumnName("rc_time");

            entity.HasOne(d => d.Citi).WithMany(p => p.ReportComments)
                .HasForeignKey(d => d.CitiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReportComment_Citizens");

            entity.HasOne(d => d.Ofi).WithMany(p => p.ReportComments)
                .HasForeignKey(d => d.OfiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReportComment_Officials");

            entity.HasOne(d => d.RIdNavigation).WithMany(p => p.ReportComments)
                .HasForeignKey(d => d.RId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReportComment_Report");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
